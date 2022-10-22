import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeManagementDto, UpdateEmployeeDto } from './employee.model';

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

  getEmployees(): Observable<EmployeeManagementDto[]> {
    return this.http.get<EmployeeManagementDto[]>('https://localhost:44343/employee');
  }

  updateEmployee(dto: UpdateEmployeeDto): Observable<number> {
    return this.http.put<number>('https://localhost:44343/employee', JSON.stringify(dto), this.headers);
  }
}
