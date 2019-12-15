import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppLayoutTwoColumnsComponent } from './app-layout-two-columns.component';
import {
  MatSidenavModule,
  MatIconModule,
  MatToolbarModule,
  MatButtonModule
} from '@angular/material';

@NgModule({
  declarations: [AppLayoutTwoColumnsComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule
  ],
  exports: [AppLayoutTwoColumnsComponent]
})
export class AppLayoutTwoColumnsModule {}
