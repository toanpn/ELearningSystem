import { ReactiveFormsModule } from '@angular/forms';
import { CourseComponent } from './pages/course/course.component';
import { DashboardSandboxService } from './dashboard.sandbox';
import { MaterialModule } from '@management-library/common-ui';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppLayoutTwoColumnsModule } from '@management-library/common-ui';
import { ManagmentLibraryLayoutComponent } from './layouts/managment-library-layout/managment-library-layout.component';
import { ManagementLibraryDashboardRoutingModule } from './management-library-dashboard-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ManagementLibraryApiModule } from '@management-library/api';
import { CourseFormDialogComponent } from './components/course-form-dialog/course-form-dialog.component';
import { CourseDetailComponent } from './pages/course-detail/course-detail.component';
const components = [ManagmentLibraryLayoutComponent, CourseFormDialogComponent];
const pages = [DashboardComponent, CourseComponent, CourseDetailComponent];
@NgModule({
  declarations: [...components, ...pages],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ManagementLibraryDashboardRoutingModule,
    ManagementLibraryApiModule,
    AppLayoutTwoColumnsModule,
    MaterialModule
  ],
  providers: [DashboardSandboxService],
  entryComponents: [CourseFormDialogComponent]
})
export class ManagementLibraryDashboardModule {
  constructor() {}
}
