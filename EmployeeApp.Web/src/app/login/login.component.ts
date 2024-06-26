import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { LoginService } from './login.service';
import { AuthResponseDto, LocalStorageKeys, UserAuthDto } from './user-auth-dto.model';

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
      username: this.loginForm.get('username')?.value,
      password: this.loginForm.get('password')?.value,
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
  private createForm(): FormGroup {
    return new FormGroup({
      username: new FormControl<string | null>(null, [Validators.required]),
      password: new FormControl<string| null>(null, [Validators.required]),
    });
  }

}
