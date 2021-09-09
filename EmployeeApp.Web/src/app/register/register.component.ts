import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IdentityResult, RegisterDto, UserAuthDto } from '../login/user-auth-dto.model';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = this.createForm();

  constructor(private registerService: RegisterService) { }

  ngOnInit(): void {
  }
  register(): void {
    const registerDto: RegisterDto = {
      email: this.registerForm.controls['email'].value,
      username: this.registerForm.controls['username'].value,
      password: this.registerForm.controls['password'].value,
    }

    this.registerService.register(registerDto)
      .subscribe(
      (response: IdentityResult) => {
        if(response.succeeded) {
          alert("you are successfully registered");
        } else {
          alert("try again");
        }
      }
    );
  }
  
  private createForm(): FormGroup {
    return new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.maxLength(256)]),
      'username': new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(50)]),
      'password': new FormControl(null, [Validators.required, Validators.minLength(7), Validators.maxLength(50)]),
    });
  }

}
