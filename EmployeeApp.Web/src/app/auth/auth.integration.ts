import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, filter, switchMap, take, tap } from "rxjs/operators";
import { AuthService } from "../login/auth.service";
import { LocalStorageKeys, RefreshTokenDto } from "../login/user-auth-dto.model";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    // private readonly token: string | null = null;
    // private readonly refreshToken: string | null = null;

    private isRefreshingToken = false;
    private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
    
    constructor(private authService: AuthService) {
        // this.token = localStorage.getItem(LocalStorageKeys.Token);
        // this.refreshToken = localStorage.getItem(LocalStorageKeys.RefreshToken);
    }

    get token(): string | null {
        return localStorage.getItem(LocalStorageKeys.Token);
    }

    get refreshToken(): string | null {
        return localStorage.getItem(LocalStorageKeys.RefreshToken);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this.token === null) {
            return next.handle(req);
        }
        
        const newRequest = this.createRequestWithTokenHeader(req); 
        return next.handle(newRequest).pipe(
            catchError(error => {
                if (error instanceof HttpErrorResponse && error.status === 401 && this.token !== null && this.refreshToken !== null) {
                    const refreshTokenDto: RefreshTokenDto = {
                        token: this.token,
                        refreshToken: this.refreshToken,
                    };
                    return this.handle401Error(newRequest, next, refreshTokenDto); //will go here if token or refresh token expired --> unauthenticated
                }

                return throwError(error);
            })
        );
    }

    private createRequestWithTokenHeader(request: HttpRequest<any>):  HttpRequest<any>{
       return request.clone({
            setHeaders: {
                'Authorization': `Bearer ${this.token}`
            }
        });
    }

    private handle401Error(request: HttpRequest<any>, next: HttpHandler, refreshTokenDto: RefreshTokenDto) {
        if (!this.isRefreshingToken) {
          this.isRefreshingToken = true;
          this.refreshTokenSubject.next(null);        
    
          return this.authService.refreshToken(refreshTokenDto).pipe(
            switchMap((responseDto: RefreshTokenDto) => {
              this.isRefreshingToken = false;
              localStorage.setItem(LocalStorageKeys.Token, responseDto.token);
              localStorage.setItem(LocalStorageKeys.RefreshToken, responseDto.refreshToken);
              this.refreshTokenSubject.next(responseDto.token);
              const newRequest = this.createRequestWithTokenHeader(request);
              return next.handle(newRequest);
            }),
            catchError((err) => {
              //if fails calling refresh api endpoint should clear storage and take 2 login
              this.isRefreshingToken = false;                  
              return throwError(err);
            })
          );
        }
    
        const newRequest = this.createRequestWithTokenHeader(request);
        // return next.handle(newRequest);
        return this.refreshTokenSubject.pipe(
          filter(token => token !== null),
          take(1),
          switchMap((token) => next.handle(newRequest))
        );
    }

    private startRefreshTokenTimer(): void {
        if (!this.token){
            return;
        }
        
        const expiry = (JSON.parse(atob(this.token.split('.')[1]))).exp;

        // set a timeout to refresh the token a minute before it expires
        const expires = new Date(jwtToken.exp * 1000);
        const timeout = expires.getTime() - Date.now() - (60 * 1000);
        this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
    }

    // private refreshToken(): Observable<RefreshTokenDto>{
    //     const token = localStorage.getItem(LocalStorageKeys.Token);
    //     const refreshToken = localStorage.getItem(LocalStorageKeys.RefreshToken);
    
    //     if (token === null || refreshToken === null) {
    //       return;
    //     }
    
    //     const dto: RefreshTokenDto = {
    //       token: token,
    //       refreshToken: refreshToken,
    //     };
    
    //     return this.authService.refreshToken(dto);
    //   }
    
    //   private tokenExpired(token: string): boolean {
    //     const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    //     return (Math.floor((new Date).getTime() / 1000)) >= expiry;
    //   }
}