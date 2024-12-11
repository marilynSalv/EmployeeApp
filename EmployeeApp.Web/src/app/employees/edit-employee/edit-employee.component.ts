import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { CompanySearchDto, ManagerSearchDto } from 'src/app/register/employee.model';
import { RegisterService } from 'src/app/register/register.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditEmployeeComponent {

  @Input() editForm!: FormGroup;

  constructor(
    private registerService: RegisterService
  ) { }

  formatCompanySearch(companyResult: CompanySearchDto): string {
    if (Boolean(companyResult.industry)) {
      return `${companyResult.name}(${companyResult.industry})`;
    }

    return `${companyResult.name}`;
  }

  formatManagerSearch(managerResult: ManagerSearchDto): string {
    if(Boolean(managerResult.companyName)) {
      return `${managerResult.lastName}, ${managerResult.firstName} (${managerResult.companyName})`;
    }

    return `${managerResult.lastName}, ${managerResult.firstName}`;
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
