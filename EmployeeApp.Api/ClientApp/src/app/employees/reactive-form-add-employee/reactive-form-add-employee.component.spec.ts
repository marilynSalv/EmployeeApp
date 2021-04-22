import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveFormAddEmployeeComponent } from './reactive-form-add-employee.component';

describe('ReactiveFormAddEmployeeComponent', () => {
  let component: ReactiveFormAddEmployeeComponent;
  let fixture: ComponentFixture<ReactiveFormAddEmployeeComponent>;

  beforeEach(async(() => {
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
