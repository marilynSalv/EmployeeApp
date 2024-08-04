import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { TokenService } from "./token.service";
import { ToastrService } from "ngx-toastr";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
  constructor(private tokenService: TokenService,
    private toastrService: ToastrService,
    private router: Router) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.tokenService.token == null) {
        return next.handle(req);
    }

    //pipe used for chaining  RxJS operator
    //Tap: Can perform side effects with observed data but does not modify the stream in any way. . You can think of it as if observable was an array over time, then tap() would be an equivalent to Array.forEach().
    const newRequest = this.createRequestWithTokenHeader(req);
    return next.handle(newRequest).pipe(
      tap({
        error: (err: any) => {
          this.handleHttpErrors(err);
        },
      })
    );
  }

  private handleHttpErrors(error: any): void {
    if (error instanceof HttpErrorResponse) {
      switch(error.status){
        case 401: {
          this.tokenService.clearGoBackToLogin();
          this.toastrService.error("Unauthorized, session has ended");
          break;
        }
        default: {
          this.toastrService.error("An unexpected error has occured");
        }
      }
    }
  }

  private createRequestWithTokenHeader(request: HttpRequest<any>):  HttpRequest<any>{
    return request.clone({
        setHeaders: {
            'Authorization': `Bearer ${this.tokenService.token}`
        }
    });
  }
}
