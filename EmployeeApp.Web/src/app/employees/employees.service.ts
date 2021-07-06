import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { 
  }

  getEmployees(): Observable<any> {
    return this.http.get('https://localhost:44343/employee');
  }

  updateEmployee(dto: Employee): Observable<any> {
    return this.http.put('https://localhost:44343/employee', JSON.stringify(dto), this.headers);
  }
}
