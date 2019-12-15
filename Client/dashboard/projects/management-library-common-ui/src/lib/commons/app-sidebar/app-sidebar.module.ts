import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppSidebarComponent } from './app-sidebar.component';

@NgModule({
  declarations: [AppSidebarComponent],
  imports: [CommonModule],
  exports: [AppSidebarComponent]
})
export class AppSidebarModule {}
