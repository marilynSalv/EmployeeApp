import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageKeys, RefreshTokenDto } from '../login/user-auth-dto.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient, private router: Router) {
  }

  get token(): string | null {
    return localStorage.getItem(LocalStorageKeys.Token);
  }

  get refreshToken(): string | null {
      return localStorage.getItem(LocalStorageKeys.RefreshToken);
  }

  isAuthenticated(): boolean {
    return this.token !== null;
  }

  refreshTokenApi(dto: RefreshTokenDto): Observable<RefreshTokenDto> {
    return this.http.post<RefreshTokenDto>('https://localhost:44343/auth/refreshToken', JSON.stringify(dto), this.headers);
  }

  logout(): Observable<any> {
    return this.http.put('https://localhost:44343/auth/logout', this.headers);
  }

  clearGoBackToLogin(): void {
    localStorage.clear();
    this.router.navigateByUrl('/login');
  }


  public startRefreshTokenTimer(): void {
    if (!this.token){
        this.clearGoBackToLogin();
        return;
    }

    const tokenExpiration = (JSON.parse(atob(this.token.split('.')[1]))).exp;

    // set a timeout to refresh the token a minute before it expires
    const expires = new Date(tokenExpiration * 1000);
    const timeout = expires.getTime() - Date.now() - (60 * 1000);
    setTimeout(() => this.callRefreshToken(), timeout);
  }

  private callRefreshToken(): void {
    if (this.token === null || this.refreshToken === null) {
      this.clearGoBackToLogin();
      return;
    }

    const dto: RefreshTokenDto = {
      token: this.token,
      refreshToken: this.refreshToken,
    };

    this.refreshTokenApi(dto)
    .subscribe({
      next: (responseDto: RefreshTokenDto) => {
        localStorage.setItem(LocalStorageKeys.Token, responseDto.token);
        localStorage.setItem(LocalStorageKeys.RefreshToken, responseDto.refreshToken);
        this.startRefreshTokenTimer();
      },
      error: () => {
        this.clearGoBackToLogin();
      }
    });
  }
}
