import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppHeaderModule } from '@management-library/common-ui';
import { LayoutsRoutingModule } from './layouts-routing.module';
import { LayoutsComponent } from './layouts.component';

@NgModule({
  declarations: [LayoutsComponent],
  imports: [CommonModule, LayoutsRoutingModule, AppHeaderModule]
})
export class LayoutsModule {
  constructor() {}
}
