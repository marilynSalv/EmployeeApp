import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IBusyConfig } from 'ng-busy';
import { Subscription } from 'rxjs';
import { EmployeeManagementDto, UpdateEmployeeDto } from './employee.model';
import { EmployeesService } from './employees.service';
import { RegisterComponent } from '../register/register.component';
import { ToastrService } from 'ngx-toastr';
import { EditEmployeeModalComponent } from './edit-employee-modal/edit-employee-modal.component';

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
    private modalService: NgbModal,
    private toastrService: ToastrService
    ) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees(): void {
    this.getSubscription = this.employeesService.getEmployees().subscribe({
      next: (data): void => {
        this.employees = data;
      }
    });
  }

  openEditEmployeeModal(employeeData: EmployeeManagementDto) {
    const modalRef = this.modalService.open(EditEmployeeModalComponent);
    modalRef.componentInstance.employeeData = employeeData;
    modalRef.result.then((refresh?: boolean) => {
      if (refresh) {
        this.getEmployees();
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
