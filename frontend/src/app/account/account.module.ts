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
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    RegisterClientComponent,
  ]
})
export class AccountModule { }
