import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { 
  }

  getController1Request(): Observable<any> {
    return this.http.get('https://localhost:44399/scope1/all');
  }
  getController2Request(): Observable<any> {
    return this.http.get('https://localhost:44399/scope2/all');
  }
}
