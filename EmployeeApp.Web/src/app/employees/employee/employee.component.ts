import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { EditEmployeeModalComponent } from '../edit-employee-modal/edit-employee-modal.component';
import { EmployeeManagementDto } from '../employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployeeComponent {
  @Input() employee = new EmployeeManagementDto();
  @Output() editEmployeeClickEvent = new EventEmitter<EmployeeManagementDto>();

  constructor() { }

  clickEditEmployee(employeeData: EmployeeManagementDto): void{
    this.editEmployeeClickEvent.emit(employeeData);
  }
}
