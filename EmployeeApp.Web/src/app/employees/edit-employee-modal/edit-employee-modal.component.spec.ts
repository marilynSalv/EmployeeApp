import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbActiveModal, NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { EditEmployeeModalComponent } from './edit-employee-modal.component';

describe('EditEmployeeModalComponent', () => {
  let component: EditEmployeeModalComponent;
  let fixture: ComponentFixture<EditEmployeeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditEmployeeModalComponent ],
      imports: [],
      providers: [
        NgbActiveModal,
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
