import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../auth/token.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private tokenService: TokenService) { }

  get showLogout(): boolean {
    return this.tokenService.token !== null;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogout(): void {
    this.tokenService.clearGoBackToLogin();
  }
}
