import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailConfirmComponent } from './account/email-confirm/email-confirm.component';
import { LoginComponent } from './account/login/login.component';
import { EmailSentComponent } from './account/register/email-sent/email-sent.component';
import { RegisterClientComponent } from './account/register/register-client/register-client.component';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'register/client', component: RegisterClientComponent },
  { path: 'register/email', component: EmailSentComponent },
  { path: 'email/confirm', component: EmailConfirmComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
