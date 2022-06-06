import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Input() employee?: Employee;
  @Output() employeeUpdated = new EventEmitter<Employee>();

  constructor() { }

  changeName(): void{
    if(this.employee !== undefined){
      this.employee.firstName = "Test";
      this.employeeUpdated.emit(this.employee);
    }
  }
}
