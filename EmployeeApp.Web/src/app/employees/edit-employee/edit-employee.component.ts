import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { IdentityResultError } from 'src/app/login/user-auth-dto.model';
import { CompanySearchDto, ManagerSearchDto } from 'src/app/register/employee.model';
import { RegisterService } from 'src/app/register/register.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent {

  @Input() editForm!: FormGroup;
  @Input() errorMessages: IdentityResultError[] = [];
  @Input() showError = false;

  constructor(
    private registerService: RegisterService
  ) { }

  closeAlert(): void {
    this.showError = false;
  }

  formatCompanySearch(companyResult: CompanySearchDto): string {
    return `${companyResult.name}(${companyResult.industry})`;
  }

  formatManagerSearch(managerResult: ManagerSearchDto): string {
    return `${managerResult.lastName}, ${managerResult.firstName} (${managerResult.companyName})`;
  }

  searchCompanies = (text$: Observable<string>) => {
    return text$.pipe(
        debounceTime(1200),
        distinctUntilChanged(),
        // switchMap allows returning an observable rather than maps array
        switchMap( (searchText) => searchText.length > 2 ? this.registerService.searchCompanies(searchText) : of([])),
    );
  }

  searchManagers = (text$: Observable<string>) => {
    return text$.pipe(
        debounceTime(1200),
        distinctUntilChanged(),
        // switchMap allows returning an observable rather than maps array
        switchMap( (searchText) => searchText.length > 2 ? this.registerService.searchManagers(searchText) : of([]) ),
    );
  }
}
