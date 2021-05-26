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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeComponent,
    EmployeesComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: EmployeesComponent, pathMatch: 'full' },
    ]),
    NgBusyModule.forRoot(new BusyConfig({
      backdrop: false,
      delay: 200,
      minDuration: 600,
      templateNgStyle: { "background-color": "black" }
  }))  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
