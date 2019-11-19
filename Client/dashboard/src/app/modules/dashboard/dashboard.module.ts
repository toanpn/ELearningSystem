import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material.module';
import { TestPageComponent } from '../test-page/test-page.component';
@NgModule({
  declarations: [
    DashboardComponent,
    TestPageComponent
  ],
  imports: [
    // Core Module
    BrowserModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    // Mat Module
    MaterialModule
  ],
  exports: [
    DashboardComponent,
    TestPageComponent
  ],
  providers: [
    DatePipe
  ]
})
export class DashboardModule {
}
//từ từ., như login thì làm thế nào để hủy bỏ top với foooter
// cha biet
// tu nhien bi mat y', thế à, còn mấy cái ông làm rât