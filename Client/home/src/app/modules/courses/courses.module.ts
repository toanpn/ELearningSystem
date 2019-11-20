import { BrowserModule} from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { CoursesComponent } from './courses.component'
import { LayoutModule } from '../../layouts/layout/layout.module'

@NgModule({
    declarations:[
        CoursesComponent
    ],
    imports: [
        BrowserModule,
        LayoutModule
    ],
    providers: [],
    bootstrap: [CoursesComponent]
})

export class CourseModule { }