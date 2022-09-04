import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterClientComponent } from './register/register-client/register-client.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { EmailSentComponent } from './register/email-sent/email-sent.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { EmailConfirmComponent } from './email-confirm/email-confirm.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { RegisterUserComponent } from './register/register-user/register-user.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    RegisterClientComponent,
    EmailSentComponent,
    EmailConfirmComponent,
    ChangePasswordComponent,
    RegisterUserComponent,
  ],
  exports: [
    LoginComponent,
    RegisterClientComponent,
    ChangePasswordComponent,
    RegisterComponent,
    RegisterUserComponent,
  ]
})
export class AccountModule { }
