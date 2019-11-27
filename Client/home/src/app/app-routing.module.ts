import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/authentication/login/login.component';
import { LayoutComponent } from './layouts/layout/layout.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './modules/home/home.component';
import { CoursesComponent } from './modules/courses/courses.component';
import { SingleCourseComponent } from './modules/single-course/single-course.component';

const ROUTES: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'courses',
        component: CoursesComponent
      },
      // {
      //   path: 'course/:id',
      //   component: CoursesComponent
      // },
      {
        path: 'course/:id',
        component: SingleCourseComponent
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  // Handle all other routes
  { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
