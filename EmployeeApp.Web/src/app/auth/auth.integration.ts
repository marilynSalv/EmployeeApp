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
    constructor(private authService: AuthService) {
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
        return next.handle(newRequest);
    }

    private createRequestWithTokenHeader(request: HttpRequest<any>):  HttpRequest<any>{
       return request.clone({
            setHeaders: {
                'Authorization': `Bearer ${this.token}`
            }
        });
    }
    
    //   private tokenExpired(token: string): boolean {
    //     const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    //     return (Math.floor((new Date).getTime() / 1000)) >= expiry;
    //   }
}