import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeManagementDto, UpdateEmployeeDto } from '../employee.model';
import { CompanySearchDto, ManagerSearchDto } from 'src/app/register/employee.model';
import { EmployeesService } from '../employees.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-employee-modal',
  templateUrl: './edit-employee-modal.component.html',
  styleUrls: ['./edit-employee-modal.component.css'],
})
export class EditEmployeeModalComponent  implements OnInit {

  @Input() employeeData: EmployeeManagementDto = {} as EmployeeManagementDto;
  editEmployeeForm: UntypedFormGroup = new UntypedFormGroup({});

  constructor(public activeModal: NgbActiveModal,
    private employeesService: EmployeesService,
    private toastrService: ToastrService
    ) {
  }

  ngOnInit(): void {
    this.editEmployeeForm = this.createForm()
  }


  private createForm(): UntypedFormGroup {
    var managerValue = null;
    var companyValue = null;
    if (this.employeeData.managerId !== null) {
      managerValue = { id: this.employeeData.managerId, firstName: this.employeeData.managerFirstName, lastName: this.employeeData.managerLastName } as ManagerSearchDto;
    }

    if(this.employeeData.companyId !== null){
      companyValue = { id: this.employeeData.companyId, name: this.employeeData.companyName } as CompanySearchDto;
    }

    var formGroup = new UntypedFormGroup({
      'firstName': new UntypedFormControl(this.employeeData.firstName, [Validators.required, Validators.maxLength(300)]),
      'lastName': new UntypedFormControl(this.employeeData.lastName, [Validators.required, Validators.maxLength(400)]),
      'zipCode': new UntypedFormControl(this.employeeData.zipCode, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new UntypedFormControl(this.employeeData.email, [Validators.required, Validators.maxLength(256)]),
      'isManager': new UntypedFormControl(this.employeeData.isManager),
      'managerSearch': new UntypedFormControl(managerValue),
      'companySearch': new UntypedFormControl(companyValue),
    });

    return formGroup;
  }

  saveEmployeeChanges(): void {
    const updatedEmployeeDto: UpdateEmployeeDto = {
      id: this.employeeData.id,
      email: this.editEmployeeForm.controls['email'].value,
      firstName: this.editEmployeeForm.controls['firstName'].value,
      lastName: this.editEmployeeForm.controls['lastName'].value,
      zipCode: this.editEmployeeForm.controls['zipCode'].value,
      isManager: this.editEmployeeForm.controls['isManager'].value === true,
      managerId: this.editEmployeeForm.controls['managerSearch'].value?.id ?? null,
      companyId: this.editEmployeeForm.controls['companySearch'].value?.id ?? null,
    }

    this.employeesService.updateEmployee(updatedEmployeeDto).subscribe(
      (): void => {
        this.toastrService.success('Sucessfully updated employee')
        this.activeModal.close(true);
      },
      () => {
        this.toastrService.error('There was an error updating the employee')
      }
    );
  }

  close(): void {
    this.activeModal.close();
  }
}
