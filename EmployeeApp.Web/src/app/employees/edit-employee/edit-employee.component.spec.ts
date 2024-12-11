import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmployeeComponent } from './edit-employee.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RegisterService } from 'src/app/register/register.service';

describe('EditEmployeeComponent', () => {
  let component: EditEmployeeComponent;
  let fixture: ComponentFixture<EditEmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule ],
      declarations: [ EditEmployeeComponent ],
      providers: [RegisterService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
