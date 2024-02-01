import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { EmployeeManagementDto } from '../employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployeeComponent {
  @Input() employee: EmployeeManagementDto = {} as EmployeeManagementDto;
  @Output() editEmployeeClickEvent = new EventEmitter<EmployeeManagementDto>();

  constructor() { }

  clickEditEmployee(employeeData: EmployeeManagementDto): void{
    this.editEmployeeClickEvent.emit(employeeData);
  }
}
