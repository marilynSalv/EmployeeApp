import { Component, OnInit } from '@angular/core';
import { RequestService } from './request.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  constructor(public requestService: RequestService) { }
  requests1: any[];
  requests2: any[];


  ngOnInit() {
    this.requestService.getController1Request().subscribe(
      (data): void => {
        this.requests1 = data;
      }
    );

    this.requestService.getController2Request().subscribe(
      (data): void => {
        this.requests2 = data;
      }
    );

  }

}
