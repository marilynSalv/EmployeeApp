import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { IdentityResult, IdentityResultError, RegisterDto, UserAuthDto } from '../login/user-auth-dto.model';
import { SearchDto } from '../shared-models/search-dto.model';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = this.createForm();
  showError = false;
  errorMessages: IdentityResultError[] = [];
  searchCompaniesSubscription?: Subscription;

  constructor(
    private registerService: RegisterService,
    private router: Router,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
  }

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
      isManager: this.registerForm.controls['isManager'].value
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

  searchCompanies(): void {
    const searchDto: SearchDto = {
      value: 'test',
      id: 4,
    };
    this.searchCompaniesSubscription = this.registerService.searchCompanies(searchDto).subscribe(x => {

    },
    );
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
      'managerSearch': new FormControl(),
      'companySearch': new FormControl(null, [Validators.required]),
    });
  }

}
