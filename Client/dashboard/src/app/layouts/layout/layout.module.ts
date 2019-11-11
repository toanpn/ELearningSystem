import {NgModule} from '@angular/core';
import {FooterComponent} from '../footer/footer.component';
import {NavigationComponent} from '../navigation/navigation.component';
import {TopnavbarComponent} from '../topnavbar/topnavbar.component';
import {LayoutComponent} from './layout.component';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {BsDropdownModule} from 'ngx-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../../shared/material.module';

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
    NavigationComponent,
    TopnavbarComponent,
    LayoutComponent
  ],
  exports: [
    FooterComponent,
    LayoutComponent,
    NavigationComponent,
    TopnavbarComponent
  ]
})
export class LayoutModule {
}
