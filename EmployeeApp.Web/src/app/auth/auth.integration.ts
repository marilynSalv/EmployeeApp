import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, filter, switchMap, take, tap } from "rxjs/operators";
import { TokenService } from "../login/token.service";
import { LocalStorageKeys, RefreshTokenDto } from "../login/user-auth-dto.model";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    constructor(private tokenService: TokenService,
      private router: Router) {
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
        return next.handle(newRequest).pipe( tap(() => {},
        (err: any) => {
          if (err instanceof HttpErrorResponse && err.status === 401) {
              localStorage.clear();
              this.router.navigate(['login']);
          }
      }));
    }

    private createRequestWithTokenHeader(request: HttpRequest<any>):  HttpRequest<any>{
       return request.clone({
            setHeaders: {
                'Authorization': `Bearer ${this.token}`
            }
        });
    }
}
