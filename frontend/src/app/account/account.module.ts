import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterClientComponent } from './register/register-client/register-client.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    RegisterClientComponent,
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    RegisterClientComponent,
  ]
})
export class AccountModule { }
