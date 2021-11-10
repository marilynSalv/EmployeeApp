import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm, FormGroup, Form, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { AuthResponseDto, UserAuthDto, LocalStorageKeys } from './user-auth-dto.model';

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
  private createForm(): FormGroup {
    return new FormGroup({
      'username': new FormControl(null, [Validators.required]),
      'password': new FormControl(null, [Validators.required]),
    });
  }

}
