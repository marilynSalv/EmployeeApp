import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {
  constructor(private router: Router, private tokenService: TokenService) {
  }

  canActivate(): boolean  {
    if (this.tokenService.isAuthenticated()) {
      return true;
    }

    this.router.navigate(['login']);
    return false;
  }
}


