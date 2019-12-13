import { BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ContactComponent } from './contact.component';
import { LayoutModule } from '../../layouts/layout/layout.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        ContactComponent
    ],
    imports: [
        BrowserModule,
        LayoutModule,
        NgbModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [],
    bootstrap: [ContactComponent]
})

export class ContactModule { }
