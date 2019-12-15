import { MaterialModule } from './../../material/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppHeaderComponent } from './app-header.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [AppHeaderComponent],
  imports: [CommonModule, MaterialModule, RouterModule],
  exports: [AppHeaderComponent]
})
export class AppHeaderModule {}
