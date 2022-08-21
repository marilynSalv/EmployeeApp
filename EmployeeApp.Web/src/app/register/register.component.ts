import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription, of } from 'rxjs';
import { IdentityResult, IdentityResultError, RegisterDto, UserAuthDto } from '../login/user-auth-dto.model';
import { RegisterService } from './register.service';
import {Observable, OperatorFunction} from 'rxjs';
import {catchError, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { SelectItemDto } from '../shared-models/search-dto.model';
import { CompanySearchDto, ManagerSearchDto } from './employee.model';


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
  registerForm: FormGroup = this.createForm();
  showError = false;
  errorMessages: IdentityResultError[] = [];
  searchCompaniesSubscription?: Subscription;

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

  updateValidators(input: string, required: boolean){
    let field = this.registerForm.get(input);
    if(!field){
       return;
    }

    if (required) {
      field.setValidators(Validators.required);
    } else {
      field.setValidators(null);
      field.patchValue(undefined);
    }

    field.updateValueAndValidity();
  }

  private createForm(): FormGroup {
    return new FormGroup({
      'firstName': new FormControl(null, [Validators.required, Validators.maxLength(300)]),
      'lastName': new FormControl(null, [Validators.required, Validators.maxLength(400)]),
      'zipCode': new FormControl(null, [Validators.required, Validators.maxLength(5), Validators.pattern('[0-9]{5}')]),
      'email': new FormControl(null, [Validators.required, Validators.maxLength(256)]),
      'username': new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(50)]),
      'password': new FormControl(null, [Validators.required, Validators.minLength(7), Validators.maxLength(50)]),
      'isManager': new FormControl(),
      'managerSearch': new FormControl(null),
      'companySearch': new FormControl(null),
    });
  }

  searchCompanies = (text$: Observable<string>) => {
    return text$.pipe(
        debounceTime(1200),
        distinctUntilChanged(),
        // switchMap allows returning an observable rather than maps array
        switchMap( (searchText) => searchText.length > 2 ? this.registerService.searchCompanies(searchText) : of([])),
    );
  }

  searchManagers = (text$: Observable<string>) => {
    return text$.pipe(
        debounceTime(1200),
        distinctUntilChanged(),
        // switchMap allows returning an observable rather than maps array
        switchMap( (searchText) => searchText.length > 2 ? this.registerService.searchManagers(searchText) : of([]) ),
    );
  }

  formatCompanySearch(companyResult: CompanySearchDto): string {
    return `${companyResult.name}(${companyResult.industry})`;
  }

  formatManagerSearch(managerResult: ManagerSearchDto): string {
    return `${managerResult.lastName}, ${managerResult.firstName} (${managerResult.companyName})`;
  }
}
