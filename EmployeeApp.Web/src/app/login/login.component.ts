import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm, FormGroup, Form, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { AuthResponseDto, UserAuthDto } from './user-auth-dto.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = this.createForm();
  showLoginError = false;
  errorMessage = '';

  constructor(private loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
  }

  closeAlert(): void {
    this.showLoginError = false;
  }

  login(): void {
    const loginDto: UserAuthDto = {
      username: this.loginForm.controls['username'].value,
      password: this.loginForm.controls['password'].value,
    }

    this.loginService.login(loginDto)
      .subscribe(
      (response: AuthResponseDto) => {
        if(response.isAuthSuccessful) {
          localStorage.setItem("token", response.token);
          this.router.navigateByUrl('/');
        }
      },
      (error) => {
        localStorage.clear();
        this.showLoginError = true;
        this.errorMessage = error?.error?.errorMessage;
        this.loginForm.controls['password'].reset('');
      }
    );
  }
  private createForm(): FormGroup {
    return new FormGroup({
      'username': new FormControl(null, [Validators.required]),
      'password': new FormControl(null, [Validators.required]),
    });
  }

}
