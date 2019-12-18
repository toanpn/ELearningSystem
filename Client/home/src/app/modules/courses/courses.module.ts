import { BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoursesComponent } from './courses.component';
import { LayoutModule } from '../../layouts/layout/layout.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        CoursesComponent
    ],
    imports: [
        BrowserModule,
        LayoutModule,
        NgbModule
    ],
    providers: [],
    bootstrap: [CoursesComponent]
})

export class CourseModule { }
