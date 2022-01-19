import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IdentityResult, UserAuthDto } from '../login/user-auth-dto.model';
import { SearchDto, SelectItemDto } from '../SharedModels/search-dto.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { 
  }

  register(dto: UserAuthDto): Observable<IdentityResult> {
    return this.http.post<any>('https://localhost:44343/auth/register', JSON.stringify(dto), this.headers);
  }

  searchCompanies(searchDto: SearchDto): Observable<SelectItemDto[]> {
    return this.http.post<SelectItemDto[]>('https://localhost:44343/company/search', JSON.stringify(searchDto), this.headers);
  }
}
