import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HierarchyType } from './employees/employee.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'EmployeeApp3.0';
  constructor(private router: Router) { 
  }
  ngOnInit(): void {
    this.router.navigate(['login'])
  }

}
