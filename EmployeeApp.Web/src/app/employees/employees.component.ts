import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IBusyConfig } from 'ng-busy';
import { Subscription } from 'rxjs';
import { EditEmployeeModalComponent } from './edit-employee-modal/edit-employee-modal.component';
import { EmployeeManagementDto, UpdateEmployeeDto } from './employee.model';
import { EmployeesService } from './employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  busyConfig: IBusyConfig = {};
  employees: EmployeeManagementDto[] = [];
  getSubscription?: Subscription;
  constructor(private employeesService: EmployeesService,
    private modalService: NgbModal
    ) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees(): void {
    this.getSubscription = this.employeesService.getEmployees().subscribe(
      (data): void => {
        this.employees = data;
      }
    );
  }

  openEditEmployeeModal(employeeData: EmployeeManagementDto) {
    const modalRef = this.modalService.open(EditEmployeeModalComponent);
    modalRef.componentInstance.employeeData = employeeData;
    // modalRef.componentInstance.saveEmployeeEditChanges.subscribe((receivedEntry: UpdateEmployeeDto) => {
    //   console.log(receivedEntry);
    // })

    modalRef.result.then((updatedEmployeeDto: UpdateEmployeeDto) => {
      if (updatedEmployeeDto) {
        this.employeesService.updateEmployee(updatedEmployeeDto).subscribe(
          (): void => {
            console.log("updated employee");
            this.getEmployees();
          }
        );
      }
    });
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
