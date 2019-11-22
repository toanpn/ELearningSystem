import { UserBusinessComponent } from './modules/users/pages/user-business/user-business.component';
import { UsersComponent } from './modules/users/users.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, OutletContext } from '@angular/router';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { LoginComponent } from './modules/authentication/login/login.component';
import { LayoutComponent } from './layouts/layout/layout.component';
import { AuthGuard } from './core/guards/auth.guard';
import { CategoryComponent } from './modules/category/category.component';
import { CategoryBusinessComponent } from './modules/category/pages/category-business/category-business.component';
import { TestComponent } from './modules/test/test.component';

const ROUTES: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'users',
        canActivate: [AuthGuard],
        component: UsersComponent
      },
      {
        path: 'user-business',
        canActivate: [AuthGuard],
        component: UserBusinessComponent
      },
      {
        path: 'categories',
        canActivate: [AuthGuard],
        component: CategoryComponent
      },
      {
        path: 'category-business',
        canActivate: [AuthGuard],
        component: CategoryBusinessComponent
      },
      {
        path: 'test/:id',
        canActivate: [AuthGuard],
        component: TestComponent
      },
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  // Handle all other routes
  { path: '**', redirectTo: '/dashboard' }
];

@NgModule({
  imports: [RouterModule.forRoot(ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
