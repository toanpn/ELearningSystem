import { BrowserModule } from '@angular/platform-browser';
import { NgModule,LOCALE_ID } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { DashboardModule } from './modules/dashboard/dashboard.module';
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
import { UsersComponent } from './modules/users/users.component';
import { UserBusinessComponent } from './modules/users/pages/user-business/user-business.component';
import { CoursesComponent } from './modules/courses/courses.component';
import { CourseBusinessComponent } from './modules/courses/course-business/course-business.component';
import { CategoryComponent } from './modules/category/category.component';
import { CategoryBusinessComponent } from './modules/category/pages/category-business/category-business.component';
import { TestComponent } from './modules/test/test.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { QuestionBusinessComponent } from './modules/test/pages/question-business/question-business.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { AddCourseComponent } from './modules/courses/course-business/add-course/add-course.component';
import localeVi from '@angular/common/locales/vi';
import { registerLocaleData } from '@angular/common';
registerLocaleData(localeVi, 'vi');
@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserBusinessComponent,
    CategoryComponent,
    CategoryBusinessComponent,
    TestComponent,
    CoursesComponent,
    CourseBusinessComponent,
    QuestionBusinessComponent,
    AddCourseComponent
  ],
  imports: [
  BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    // Third Module
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    // Routing Module
    AppRoutingModule,
    // Material Module
    MaterialModule,
    // Main Module
    LayoutModule,
    DashboardModule,
    AuthModule,
    ComponentModule,
    CoreModule,
    // ckeditor
    CKEditorModule,
    CurrencyMaskModule
  ],
  providers: [
    ShareService,
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlVN },
    {
      provide: LOCALE_ID,
      useValue: 'vi' // 'de' for Germany, 'fr' for France ...
     }
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
