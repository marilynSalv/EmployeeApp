import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BusyConfig, NgBusyModule } from 'ng-busy';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeesComponent } from './employees/employees.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CustomBusyComponent } from './custom-busy/custom-busy.component';
import { ScopeComponent } from './scope/scope.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeComponent,
    EmployeesComponent,
    CustomBusyComponent,
    ScopeComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    NgBusyModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: EmployeesComponent, pathMatch: 'full' },
      { path: 'scope', component: ScopeComponent, pathMatch: 'full' },
    ]),
    NgBusyModule.forRoot(new BusyConfig({
      backdrop: true,
      template: CustomBusyComponent,
      minDuration: 600,
  })) ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
