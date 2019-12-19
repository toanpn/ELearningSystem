import { CartComponent } from './modules/cart/cart.component';
import { MyCourseComponent } from './modules/my-course/my-course.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/authentication/login/login.component';
import { LayoutComponent } from './layouts/layout/layout.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './modules/home/home.component';
import { CoursesComponent } from './modules/courses/courses.component';
import { SingleCourseComponent } from './modules/single-course/single-course.component';
import { AboutComponent } from './modules/about/about.component';
import { ContactComponent } from './modules/contact/contact.component';
import { TestComponent } from './modules/test/test.component';
import { StudyComponent } from './modules/study/study.component';

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
        path: 'test/:courseId/:chapterId',
        component: TestComponent
      },
      {
        path: 'courses',
        component: CoursesComponent
      },
      {
        path: 'about',
        component: AboutComponent
      },
      {
        path: 'contact',
        component: ContactComponent
      },
      {
        path: 'course/:id',
        component: SingleCourseComponent
      },
      {
        path: 'my-course',
        component: MyCourseComponent
      },
      {
        path: 'study/:id',
        component: StudyComponent
      },
      {
        path: 'cart',
        component: CartComponent
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
