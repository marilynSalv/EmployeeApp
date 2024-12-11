import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { EditEmployeeModalComponent } from './edit-employee-modal.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { EmployeesService } from '../employees.service';
import { ToastrService } from 'ngx-toastr';
import { ToastrModule } from 'ngx-toastr';

describe('EditEmployeeModalComponent', () => {
  let component: EditEmployeeModalComponent;
  let fixture: ComponentFixture<EditEmployeeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditEmployeeModalComponent ],
      imports: [HttpClientTestingModule, ToastrModule.forRoot({
        positionClass :'toast-bottom-right',
      })],
      providers: [
        NgbActiveModal, EmployeesService, ToastrService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEmployeeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
