import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageKeys, RefreshTokenDto } from './user-auth-dto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { 
  }

  get token(): string | null {
    return localStorage.getItem(LocalStorageKeys.Token);
  }

  get refreshToken(): string | null {
      return localStorage.getItem(LocalStorageKeys.RefreshToken);
  }


  refreshTokenApi(dto: RefreshTokenDto): Observable<RefreshTokenDto> {
    return this.http.post<RefreshTokenDto>('https://localhost:44343/auth/refreshToken', JSON.stringify(dto), this.headers);
  }

  
  public startRefreshTokenTimer(): void {
    if (!this.token){
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
      return;
    }

    const dto: RefreshTokenDto = {
      token: this.token,
      refreshToken: this.refreshToken,
    };

    this.refreshTokenApi(dto)
    .subscribe(
        (responseDto: RefreshTokenDto) => {
            localStorage.setItem(LocalStorageKeys.Token, responseDto.token);
            localStorage.setItem(LocalStorageKeys.RefreshToken, responseDto.refreshToken);
            this.startRefreshTokenTimer();
        }
    );
  }
}
