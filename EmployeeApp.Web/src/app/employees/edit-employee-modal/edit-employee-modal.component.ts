import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-edit-employee-modal',
  templateUrl: './edit-employee-modal.component.html',
  styleUrls: ['./edit-employee-modal.component.css']
})
export class EditEmployeeModalComponent  {

  constructor(public activeModal: NgbActiveModal) { }

  @Input() employeeData = new Employee();

  editEmployeeForm: FormGroup = this.createForm();

  private createForm(): FormGroup {
    console.log('test');
    console.log(this.employeeData.firstName);

    console.log(this.employeeData.zipCode);
    return new FormGroup({
      'zipCode': new FormControl(this.employeeData.zipCode, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new FormControl(this.employeeData.email, [Validators.required, Validators.maxLength(256)]),
    });
  }

}
