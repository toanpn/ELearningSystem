import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material.module';
@NgModule({
  declarations: [DashboardComponent],
  imports: [
    // Core Module
    BrowserModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    // Mat Module
    MaterialModule
  ],
  exports: [DashboardComponent],
  providers: [DatePipe]
})
export class DashboardModule {}
