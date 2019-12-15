import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ManagmentLibraryLayoutComponent } from './layouts/managment-library-layout/managment-library-layout.component';
import { CourseComponent } from './pages/course/course.component';

const routes: Routes = [
  {
    path: '',
    component: ManagmentLibraryLayoutComponent,
    children: [
      {
        path: 'home',
        component: DashboardComponent,
        data: { title: 'Dashboard', type: 'Dashboard' }
      },
      {
        path: 'manager-course',
        component: CourseComponent,
        data: { title: 'Quản lý khoá học', type: 'Course' }
      }
    ]
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'prefix'
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagementLibraryDashboardRoutingModule {}
