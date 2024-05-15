import { Component, Input } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription, of } from 'rxjs';
import { IdentityResult, IdentityResultError, RegisterDto } from '../login/user-auth-dto.model';
import { RegisterService } from './register.service';
import { EmployeeManagementDto } from '../employees/employee.model';


const states = ['Alabama', 'Alaska', 'American Samoa', 'Arizona', 'Arkansas', 'California', 'Colorado',
  'Connecticut', 'Delaware', 'District Of Columbia', 'Federated States Of Micronesia', 'Florida', 'Georgia',
  'Guam', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine',
  'Marshall Islands', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana',
  'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
  'Northern Mariana Islands', 'Ohio', 'Oklahoma', 'Oregon', 'Palau', 'Pennsylvania', 'Puerto Rico', 'Rhode Island',
  'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virgin Islands', 'Virginia',
  'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: UntypedFormGroup = this.createForm();
  showError = false;
  errorMessages: IdentityResultError[] = [];
  searchCompaniesSubscription?: Subscription;

  @Input() isMgmtEdit = false;
  @Input() employeeData?: EmployeeManagementDto;

  constructor(
    private registerService: RegisterService,
    private router: Router,
    private toastrService: ToastrService) { }

  closeAlert(): void {
    this.showError = false;
  }

  register(): void {
    const registerDto: RegisterDto = {
      email: this.registerForm.controls['email'].value,
      username: this.registerForm.controls['username'].value,
      password: this.registerForm.controls['password'].value,
      firstName: this.registerForm.controls['firstName'].value,
      lastName: this.registerForm.controls['lastName'].value,
      zipCode: this.registerForm.controls['zipCode'].value,
      isManager: this.registerForm.controls['isManager'].value === true,
      managerId: this.registerForm.controls['managerSearch'].value?.id ?? null,
      companyId: this.registerForm.controls['companySearch'].value?.id ?? null,
    }

    this.registerService.register(registerDto)
      .subscribe(
      (response: IdentityResult) => {
        if(response.succeeded) {
          this.router.navigate(['login'])
          this.toastrService.success('Sucessfully created account');
        } else {
          this.showError = true;
          this.errorMessages = response.errors;
        }
      }
    );
  }

  private createForm(): UntypedFormGroup {
    var formGroup = new UntypedFormGroup({
      'username': new UntypedFormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(50)]),
      'password': new UntypedFormControl(null, [Validators.required, Validators.minLength(7), Validators.maxLength(50)]),
      'firstName': new UntypedFormControl(null, [Validators.required, Validators.maxLength(300)]),
      'lastName': new UntypedFormControl(null, [Validators.required, Validators.maxLength(400)]),
      'zipCode': new UntypedFormControl(null, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new UntypedFormControl(null, [Validators.required, Validators.maxLength(256)]),
      'isManager': new UntypedFormControl(null),
      'managerSearch': new UntypedFormControl(null),
      'companySearch': new UntypedFormControl(null),
    });

    return formGroup;
  }
}
