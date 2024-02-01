import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeManagementDto, UpdateEmployeeDto } from '../employee.model';
import { CompanySearchDto, ManagerSearchDto } from 'src/app/register/employee.model';

@Component({
  selector: 'app-edit-employee-modal',
  templateUrl: './edit-employee-modal.component.html',
  styleUrls: ['./edit-employee-modal.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditEmployeeModalComponent  implements OnInit {

  @Input() employeeData: EmployeeManagementDto = {} as EmployeeManagementDto;
  editEmployeeForm: FormGroup = this.createForm();

  constructor(public activeModal: NgbActiveModal) {
    this.editEmployeeForm =  this.createForm();
  }

  ngOnInit(): void {
    this.editEmployeeForm = this.createForm()
  }


  private createForm(): FormGroup {
    var managerValue = null;
    var companyValue = null;
    if (this.employeeData.managerId !== null) {
      managerValue = { id: this.employeeData.managerId, firstName: this.employeeData.managerFirstName, lastName: this.employeeData.managerLastName } as ManagerSearchDto;
    }

    if(this.employeeData.companyId !== null){
      companyValue = { id: this.employeeData.companyId, name: this.employeeData.companyName } as CompanySearchDto;
    }

    var formGroup = new FormGroup({
      'firstName': new FormControl(this.employeeData.firstName, [Validators.required, Validators.maxLength(300)]),
      'lastName': new FormControl(this.employeeData.lastName, [Validators.required, Validators.maxLength(400)]),
      'zipCode': new FormControl(this.employeeData.zipCode, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new FormControl(this.employeeData.email, [Validators.required, Validators.maxLength(256)]),
      'isManager': new FormControl(this.employeeData.isManager),
      'managerSearch': new FormControl(managerValue),
      'companySearch': new FormControl(companyValue),
    });

    return formGroup;
  }

  saveEmployeeChanges(): void {
    const updateEmployeeDto: UpdateEmployeeDto = {
      id: this.employeeData.id,
      email: this.editEmployeeForm.controls['email'].value,
      firstName: this.editEmployeeForm.controls['firstName'].value,
      lastName: this.editEmployeeForm.controls['lastName'].value,
      zipCode: this.editEmployeeForm.controls['zipCode'].value,
      isManager: this.editEmployeeForm.controls['isManager'].value === true,
      managerId: this.editEmployeeForm.controls['managerSearch'].value?.id ?? null,
      companyId: this.editEmployeeForm.controls['companySearch'].value?.id ?? null,
    }

    this.activeModal.close(updateEmployeeDto);
  }

  close(): void {
    this.activeModal.close();
  }
}
