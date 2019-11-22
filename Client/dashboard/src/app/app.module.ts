import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
import { TestCreateComponent } from './modules/test/pages/test-create/test-create.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserBusinessComponent,
    CategoryComponent,
    CategoryBusinessComponent,
    TestComponent,
    TestCreateComponent,
    CoursesComponent,
    CourseBusinessComponent
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
    CoreModule
  ],
  providers: [
    ShareService,
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlVN }
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
