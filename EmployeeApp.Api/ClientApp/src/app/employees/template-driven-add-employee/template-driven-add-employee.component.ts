import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-template-driven-add-employee',
  templateUrl: './template-driven-add-employee.component.html',
  styleUrls: ['./template-driven-add-employee.component.css']
})
export class TemplateDrivenAddEmployeeComponent implements OnInit {
  @ViewChild('addEmployeeForm', { static: false }) courseForm: NgForm;
  newEmloyee: Employee;

  constructor() { }

  ngOnInit() {
  }


}
