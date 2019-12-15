import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { NgModule } from '@angular/core';
const components = [];
@NgModule({
  declarations: [...components],
  imports: [CommonModule, MaterialModule],
  exports: [...components]
})
export class ManagementLibraryCommonUiModule {}
