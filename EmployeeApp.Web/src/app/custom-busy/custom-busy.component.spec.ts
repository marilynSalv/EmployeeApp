import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomBusyComponent } from './custom-busy.component';

describe('CustomBusyComponent', () => {
  let component: CustomBusyComponent;
  let fixture: ComponentFixture<CustomBusyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomBusyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomBusyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
