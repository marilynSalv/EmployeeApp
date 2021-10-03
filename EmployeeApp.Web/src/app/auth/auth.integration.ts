import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    // private readonly token: string;

    constructor() {
        // this.token = localStorage.getItem('token');
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (localStorage.getItem('token')) {
            const modReq = req.clone({
                setHeaders: {
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                }
            });
            return next.handle(modReq).pipe(
                tap (
                success => {console.log('success')},
                error => {console.log('error')}
             ));
        }
        return next.handle(req);
    }
}