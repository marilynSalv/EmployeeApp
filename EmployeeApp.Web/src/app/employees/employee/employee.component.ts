import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { EditEmployeeModalComponent } from '../edit-employee-modal/edit-employee-modal.component';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployeeComponent {
  // @Input() firstName: string;
  // @Input() lastName: string;
  // @Input() email: string;
  @Input() employee = new Employee();
  @Output() employeeUpdated = new EventEmitter<Employee>();

  constructor(private modalService: NgbModal) { }

  open(employeeData: Employee) {
    const modalRef = this.modalService.open(EditEmployeeModalComponent);
    modalRef.componentInstance.employeeData = employeeData;
  }

  changeName(): void{
    if(this.employee !== undefined){
      this.employee.firstName = "Test";
      this.employeeUpdated.emit(this.employee);
    }
  }
}
