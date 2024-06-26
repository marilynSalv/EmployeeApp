import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompanySearchDto, ManagerSearchDto } from 'src/app/register/employee.model';
import { EmployeeManagementDto, UpdateEmployeeDto } from '../employee.model';
import { EmployeesService } from '../employees.service';

@Component({
  selector: 'app-edit-employee-modal',
  templateUrl: './edit-employee-modal.component.html',
  styleUrls: ['./edit-employee-modal.component.css'],
})
export class EditEmployeeModalComponent  implements OnInit {

  @Input() employeeData: EmployeeManagementDto = {} as EmployeeManagementDto;
  editEmployeeForm: FormGroup = new FormGroup({});

  constructor(public activeModal: NgbActiveModal,
    private employeesService: EmployeesService,
    private toastrService: ToastrService
    ) {
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
      firstName: new FormControl(this.employeeData.firstName, [Validators.required, Validators.maxLength(300)]),
      lastName: new FormControl(this.employeeData.lastName, [Validators.required, Validators.maxLength(400)]),
      zipCode: new FormControl(this.employeeData.zipCode, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      email: new FormControl(this.employeeData.email, [Validators.required, Validators.maxLength(256)]),
      isManager: new FormControl(this.employeeData.isManager),
      managerSearch: new FormControl<ManagerSearchDto | null>(managerValue),
      companySearch: new FormControl<CompanySearchDto | null>(companyValue),
    });

    return formGroup;
  }

  saveEmployeeChanges(): void {
    const updatedEmployeeDto: UpdateEmployeeDto = {
      id: this.employeeData.id,
      email: this.editEmployeeForm.get('email')?.value,
      firstName: this.editEmployeeForm.get('firstName')?.value,
      lastName: this.editEmployeeForm.get('lastName')?.value,
      zipCode: this.editEmployeeForm.get('zipCode')?.value,
      isManager: this.editEmployeeForm.get('isManager')?.value === true,
      managerId: this.editEmployeeForm.get('managerSearch')?.value?.id ?? null,
      companyId: this.editEmployeeForm.get('companySearch')?.value?.id ?? null,
    }

    this.employeesService.updateEmployee(updatedEmployeeDto).subscribe({
      next: (): void => {
        this.toastrService.success('Sucessfully updated employee')
        this.activeModal.close(true);
      },
      error: () => {
        this.toastrService.error('There was an error updating the employee')
      }
    });
  }

  close(): void {
    this.activeModal.close();
  }
}
