import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from './account/change-password/change-password.component';
import { EmailConfirmComponent } from './account/email-confirm/email-confirm.component';
import { LoginComponent } from './account/login/login.component';
import { EmailSentComponent } from './account/register/email-sent/email-sent.component';
import { RegisterClientComponent } from './account/register/register-client/register-client.component';
import { RegisterComponent } from './account/register/register.component';
import { BoatComponent } from './boats/boat/boat.component';
import { BoatsComponent } from './boats/boats.component';
import { ClientProfileComponent } from './client/client-profile/client-profile.component';
import { CottageComponent } from './cottages/cottage/cottage.component';
import { CottagesComponent } from './cottages/cottages.component';
import { HomeComponent } from './home/home.component';
import { SpecialOffersComponent } from './special-offers/special-offers.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'register/client', component: RegisterClientComponent },
  { path: 'register/email', component: EmailSentComponent },
  { path: 'email/confirm', component: EmailConfirmComponent },
  { path: 'client/profile', component: ClientProfileComponent, canActivate: [AuthGuard]},
  { path: 'password', component: ChangePasswordComponent, canActivate: [AuthGuard]},
  { path: 'cottages', component: CottagesComponent },
  { path: 'cottage/:id', component: CottageComponent },
  { path: 'boats', component: BoatsComponent },
  { path: 'boat/:id', component: BoatComponent },
  { path: 'special-offers', component: SpecialOffersComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
