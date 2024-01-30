import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BusyConfig, NgBusyModule } from 'ng-busy';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeesComponent } from './employees/employees.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomBusyComponent } from './custom-busy/custom-busy.component';
import { ScopeComponent } from './scope/scope.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EmployeesService } from './employees/employees.service';
import { AuthInterceptor } from './auth/auth.integration';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EditEmployeeComponent } from './employees/edit-employee/edit-employee.component';
import { EditEmployeeModalComponent } from './employees/edit-employee-modal/edit-employee-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeComponent,
    EmployeesComponent,
    CustomBusyComponent,
    ScopeComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    EditEmployeeComponent,
    EditEmployeeModalComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    NgBusyModule.forRoot(new BusyConfig({
      backdrop: true,
      template: CustomBusyComponent,
      minDuration: 200,
    })),
    ToastrModule.forRoot({
      positionClass :'toast-bottom-right',
    })
  ],
  providers: [
    EmployeesService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
