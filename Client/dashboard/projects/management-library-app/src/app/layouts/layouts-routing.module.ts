import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutsComponent } from './layouts.component';

const routes: Routes = [
  {
    path: 'app',
    component: LayoutsComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import('@management-library/dashboard').then(
            m => m.ManagementLibraryDashboardModule
          )
      }
    ]
  },
  {
    path: '',
    redirectTo: '/app/dashboard',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutsRoutingModule {}
