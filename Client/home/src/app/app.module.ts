import { SafePipeModule } from 'safe-pipe';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './modules/authentication/auth.module';
import { LayoutModule } from './layouts/layout/layout.module';
import { MaterialModule } from './shared/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ShareService } from './shared/services/share.service';
import { ComponentModule } from './core/components/component.module';
import { MatPaginatorIntl } from '@angular/material';
import { MatPaginatorIntlVN } from './core/extends/vietnamese-paginator-intl';
import { CoreModule } from './core/core.module';
import { CourseModule } from './modules/courses/courses.module';
import { HomeModule } from './modules/home/home.module';
import { SingleCourseComponent } from './modules/single-course/single-course.component';
import { ContactModule } from './modules/contact/contact.module';
import { AboutModule } from './modules/about/about.module';
import { TestComponent } from './modules/test/test.component';
import { StudyComponent } from './modules/study/study.component';
import { TabsModule } from 'ngx-bootstrap';
import { MyCourseComponent } from './modules/my-course/my-course.component';
import { CartComponent } from './modules/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    SingleCourseComponent,
    TestComponent,
    StudyComponent,
    MyCourseComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SafePipeModule,
    // Third Module
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    // Routing Module
    AppRoutingModule,
    // Material Module
    MaterialModule,
    // Main Module
    LayoutModule,
    AuthModule,
    ComponentModule,
    CoreModule,
    CourseModule,
    HomeModule,
    ContactModule,
    AboutModule,
    TabsModule.forRoot()
  ],
  providers: [
    ShareService,
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlVN }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
