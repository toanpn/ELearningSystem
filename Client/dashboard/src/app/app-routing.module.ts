import { UserBusinessComponent } from './modules/users/pages/user-business/user-business.component';
import { UsersComponent } from './modules/users/users.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, OutletContext } from '@angular/router';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { LoginComponent } from './modules/authentication/login/login.component';
import { LayoutComponent } from './layouts/layout/layout.component';
import { AuthGuard } from './core/guards/auth.guard';

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
        path: 'user-business',/
        doity/ them 1 router
        canActivate: [AuthGuard],
        component: UserBusinessComponent
      },
    ]
  },
  //hỏi hăng ;), sẵn sàng fb ,
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
//hiểu r, đù má, ngoài 2 cái này thì ông làm những cái t học được trong tuần này r :)), có gì khó nữa ko chỉ phát nữa
// ông giỏi thì cái gì xung dẽ
// như cái view dùng chung tìm hoài méo thấy đâu, ban đầu thấy trong này có layoutcompo... tưởng là view mặc định của angular
// đọc về router route-outlet