import { Component, OnInit } from '@angular/core';
import { IBusyConfig } from 'ng-busy';
import { Subscription } from 'rxjs';
import { Employee } from './employee.model';
import { EmployeesService } from './employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  busyConfig: IBusyConfig = {};
  employees: Employee[] = [];
  getSubscription?: Subscription;
  constructor(private employeesService: EmployeesService,
    // private bsModalService?: BsModalService,
    ) { }

  ngOnInit() {
    this.getSubscription = this.employeesService.getEmployees().subscribe(
      (data): void => {
        this.employees = data;
      }
    );
  }

  update(updatedEmployee : Employee):void {
    this.employeesService.updateEmployee(updatedEmployee).subscribe(
      (): void => {
        console.log("updated employee");
      }
    );
  }

  addEmployee(): void{

  }

  onClick() {

    const busy = new Promise<any>((resolve) => {
      setTimeout((): void => {
        Promise.resolve();
      }, 5000);
    });
    this.busyConfig.busy = [busy];
  }

}
