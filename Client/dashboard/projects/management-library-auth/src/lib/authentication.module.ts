import { AuthenticationRoutingModule } from './authentication-routing.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { LoginComponent } from './pages/login/login.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MaterialModule } from '@management-library/common-ui';
import { ReactiveFormsModule } from '@angular/forms';
import { ManagementLibraryApiModule } from '@management-library/api';

@NgModule({
  declarations: [LoginComponent, LoginFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthenticationRoutingModule,
    MaterialModule,
    ManagementLibraryApiModule
  ]
})
export class AuthenticationModule {}
