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
import { ChapterComponent } from './pages/chapter/chapter.component';
import { ChapterFormDialogComponent } from './components/chapter-form-dialog/chapter-form-dialog.component';
import { LessonFormDialogComponent } from './components/lesson-form-dialog/lesson-form-dialog.component';
import { CategoryComponent } from './pages/category/category.component';
import { CategoryFormDialogComponent } from './components/category-form-dialog/category-form-dialog.component';
const components = [
  ManagmentLibraryLayoutComponent,
  CourseFormDialogComponent,
  ChapterFormDialogComponent,
  LessonFormDialogComponent
];
const pages = [DashboardComponent, CourseComponent, ChapterComponent];
@NgModule({
  declarations: [...components, ...pages, CategoryComponent, CategoryFormDialogComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ManagementLibraryDashboardRoutingModule,
    ManagementLibraryApiModule,
    AppLayoutTwoColumnsModule,
    MaterialModule
  ],
  providers: [DashboardSandboxService],
  entryComponents: [
    CourseFormDialogComponent,
    ChapterFormDialogComponent,
    LessonFormDialogComponent,
    CategoryFormDialogComponent
  ]
})
export class ManagementLibraryDashboardModule {
  constructor() {}
}
