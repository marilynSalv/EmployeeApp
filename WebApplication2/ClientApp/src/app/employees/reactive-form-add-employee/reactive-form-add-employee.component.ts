import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-form-add-employee',
  templateUrl: './reactive-form-add-employee.component.html',
  styleUrls: ['./reactive-form-add-employee.component.css']
})
export class ReactiveFormAddEmployeeComponent implements OnInit {
  newEmployeeForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

  private initForm() {
    this.newEmployeeForm = new FormGroup({
      'firstName': new FormControl(null, Validators.required),
      'lastName': new FormControl(null, [Validators.required, Validators.maxLength(250)]),
      'email': new FormControl(null, Validators.required)
    });
  }
}