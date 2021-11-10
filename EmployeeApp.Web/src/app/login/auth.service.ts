import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RefreshTokenDto } from './user-auth-dto.model';

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

  refreshToken(dto: RefreshTokenDto): Observable<RefreshTokenDto> {
    return this.http.post<RefreshTokenDto>('https://localhost:44343/auth/refreshToken', JSON.stringify(dto), this.headers);
  }
}
