import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardComponent} from './modules/dashboard/dashboard.component';
import {LoginComponent} from './modules/authentication/login/login.component';
import {LayoutComponent} from './layouts/layout/layout.component';
import {AuthGuard} from './core/guards/auth.guard';

const ROUTES: Routes = [
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard]
      },
      // router user profile
      // {
      //   path: 'notifications',
      //   canActivate: [AuthGuard],
      //   component: ListNotificationComponent
      // },
    ]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  // Handle all other routes
  {path: '**', redirectTo: '/dashboard'}
];


@NgModule({
  imports: [RouterModule.forRoot(ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
