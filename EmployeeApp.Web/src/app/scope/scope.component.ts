import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { RequestDto } from './scope.model';
import { ScopeService } from './scope.service';

@Component({
  selector: 'app-scope',
  templateUrl: './scope.component.html',
  styleUrls: ['./scope.component.css']
})
export class ScopeComponent implements OnInit {
  getSubscription?: Subscription;
  requests?: RequestDto[];
  constructor(private scopeService: ScopeService) { }

  ngOnInit(): void {
    this.getRequests();
  }
  
  getRequests(): void {
    this.getSubscription = this.scopeService.getScopeExample().subscribe(
      (data: RequestDto[]): void => {
        this.requests = data;
      }
    );
  }

}
