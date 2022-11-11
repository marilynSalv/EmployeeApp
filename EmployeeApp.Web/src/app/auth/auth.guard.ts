import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../login/auth.service';
import { LocalStorageKeys, RefreshTokenDto } from '../login/user-auth-dto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean  {
      var token = localStorage.getItem(LocalStorageKeys.Token);
      if(token !== null) {
        return true;
      }

    this.router.navigate(['login']);
    return false;
  }

}
