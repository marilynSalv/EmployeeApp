import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDrivenAddEmployeeComponent } from './template-driven-add-employee.component';

describe('TemplateDrivenAddEmployeeComponent', () => {
  let component: TemplateDrivenAddEmployeeComponent;
  let fixture: ComponentFixture<TemplateDrivenAddEmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateDrivenAddEmployeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateDrivenAddEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
