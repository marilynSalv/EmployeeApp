import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeManagementDto, UpdateEmployeeDto } from '../employee.model';

@Component({
  selector: 'app-edit-employee-modal',
  templateUrl: './edit-employee-modal.component.html',
  styleUrls: ['./edit-employee-modal.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditEmployeeModalComponent  implements OnInit {

  @Input() employeeData = new EmployeeManagementDto();

  editEmployeeForm: FormGroup;

  constructor(public activeModal: NgbActiveModal) {
    this.editEmployeeForm =  this.createForm();
  }

  ngOnInit(): void {
    this.editEmployeeForm = this.createForm()
  }


  private createForm(): FormGroup {
    let form = new FormGroup({
      'zipCode': new FormControl(this.employeeData.zipCode, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new FormControl(this.employeeData.email, [Validators.required, Validators.maxLength(256)]),
    });

    return form;
  }

  saveEmployeeChanges(): void {
    const updateEmployeeDto: UpdateEmployeeDto = {

      id: this.employeeData.id,
      email: this.editEmployeeForm.controls['email'].value,
      zipCode: this.editEmployeeForm.controls['zipCode'].value,
    }

    this.activeModal.close(updateEmployeeDto);
  }

}
