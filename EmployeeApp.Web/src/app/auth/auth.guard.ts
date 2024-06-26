import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { LocalStorageKeys } from '../login/user-auth-dto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard  {
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
