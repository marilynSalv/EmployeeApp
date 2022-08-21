import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IdentityResult, UserAuthDto } from '../login/user-auth-dto.model';
import { SelectItemDto } from '../shared-models/search-dto.model';
import { CompanySearchDto, ManagerSearchDto } from './employee.model';

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

  searchCompanies(searchValue: string): Observable<CompanySearchDto[]> {
    return this.http.post<CompanySearchDto[]>('https://localhost:44343/company/search', JSON.stringify(searchValue), this.headers);
  }

  searchManagers(searchValue: string): Observable<ManagerSearchDto[]> {
    return this.http.post<ManagerSearchDto[]>('https://localhost:44343/ManagerSearch', JSON.stringify(searchValue), this.headers);
  }
}
