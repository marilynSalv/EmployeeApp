import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthResponseDto, UserAuthDto } from './user-auth-dto.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { 
  }

  login(dto: UserAuthDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>('https://localhost:44343/auth/login', JSON.stringify(dto), this.headers);
  }
}
