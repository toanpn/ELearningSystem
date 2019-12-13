import { BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AboutComponent } from './about.component';
import { LayoutModule } from '../../layouts/layout/layout.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        AboutComponent
    ],
    imports: [
        BrowserModule,
        LayoutModule,
        NgbModule
    ],
    providers: [],
    bootstrap: [AboutComponent]
})

export class AboutModule { }
