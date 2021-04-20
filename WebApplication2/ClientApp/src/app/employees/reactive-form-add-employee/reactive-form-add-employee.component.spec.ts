import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ReactiveFormAddEmployeeComponent } from './reactive-form-add-employee.component';

describe('ReactiveFormAddEmployeeComponent', () => {
  let component: ReactiveFormAddEmployeeComponent;
  let fixture: ComponentFixture<ReactiveFormAddEmployeeComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ReactiveFormAddEmployeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReactiveFormAddEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
