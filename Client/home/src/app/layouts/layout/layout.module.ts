import {NgModule} from '@angular/core';
import {FooterComponent} from '../footer/footer.component';
import {TopnavbarComponent} from '../topnavbar/topnavbar.component';
import {LayoutComponent} from './layout.component';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {BsDropdownModule} from 'ngx-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../../shared/material.module';
import { BreadcrumComponent } from '../breadcrum/breadcrum.component';
import { RightmenuComponent } from '../rightmenu/rightmenu.component';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    BsDropdownModule.forRoot(),
  ],
  declarations: [
    FooterComponent,
    TopnavbarComponent,
    LayoutComponent,
    BreadcrumComponent,
    RightmenuComponent
  ],
  exports: [
    FooterComponent,
    LayoutComponent,
    TopnavbarComponent,
    BreadcrumComponent,
    RightmenuComponent
  ]
})
export class LayoutModule {
}
