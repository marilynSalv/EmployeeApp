import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EmployeesService } from './employees.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'EmployeeApp3.0';
  employees: any = []
  getSubscription?: Subscription;
  constructor(private employeesService: EmployeesService) { }

  ngOnInit() {
    this.getSubscription = this.employeesService.getEmployees().subscribe(
      (data): void => {
        this.employees = data;
      }
    );
  }
}
