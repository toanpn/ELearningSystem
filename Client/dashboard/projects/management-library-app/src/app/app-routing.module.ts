import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from '@management-library/core';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./layouts/layouts.module').then(module => module.LayoutsModule),
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('@management-library/auth').then(
        module => module.AuthenticationModule
      )
  },
  {
    path: '**',
    redirectTo: '/app/dashboard',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
