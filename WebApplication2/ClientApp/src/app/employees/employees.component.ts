import { Component, OnInit } from '@angular/core';
import { Employee } from './employee.model';
import { EmployeesService } from './employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = 
  [{ 
    firstName: 'Testy', 
    lastName:'Roberts', 
    email: 'test@gmail.com',
  },
  { 
    firstName: 'Testy2', 
    lastName:'Roberts2', 
    email: 'tes2t@gmail.com',
  }];
  constructor(private employeesService: EmployeesService,
    // private bsModalService?: BsModalService,
    ) { }

  ngOnInit() {
    this.employeesService.getEmployees().subscribe(
      (data): void => {
        this.employees = data;
      }
    );
  }

  changeFirstEmployeeName():void {
    this.employees[0].firstName = "Jessy";
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

}
