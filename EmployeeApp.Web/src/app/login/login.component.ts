import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm, UntypedFormGroup, Form, UntypedFormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { LoginService } from './login.service';
import { AuthResponseDto, UserAuthDto, LocalStorageKeys } from './user-auth-dto.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: UntypedFormGroup = this.createForm();
  showLoginError = false;
  errorMessage = '';

  constructor(private loginService: LoginService,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') !== null){
      this.router.navigateByUrl('/employees');
    }
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
          localStorage.setItem(LocalStorageKeys.Token, response.token);
          localStorage.setItem(LocalStorageKeys.RefreshToken, response.refreshToken);
          this.authService.startRefreshTokenTimer();
          this.router.navigateByUrl('/employees');
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
  private createForm(): UntypedFormGroup {
    return new UntypedFormGroup({
      'username': new UntypedFormControl(null, [Validators.required]),
      'password': new UntypedFormControl(null, [Validators.required]),
    });
  }

}
