import { BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { LayoutModule } from '../../layouts/layout/layout.module';

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        BrowserModule,
        LayoutModule
    ],
    providers: [],
    bootstrap: [HomeComponent]
})

export class HomeModule { }
