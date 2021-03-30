import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployeeComponent implements OnInit {
  // @Input() firstName: string;
  // @Input() lastName: string;
  // @Input() email: string;
  @Input() employee: Employee;
  @Output() employeeUpdated = new EventEmitter<Employee>();

  constructor() { }

  ngOnInit() {
  }

  changeName(): void{
    this.employee.firstName = "Test";
    this.employeeUpdated.emit(this.employee);
  }
}
