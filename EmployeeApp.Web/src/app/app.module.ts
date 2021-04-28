import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BusyConfig, NgBusyModule } from 'ng-busy';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    NgBusyModule.forRoot(new BusyConfig({
      message: 'Don\'t panic!',
      backdrop: false,
      delay: 200,
      minDuration: 600,
      templateNgStyle: { "background-color": "black" }
  }))  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
