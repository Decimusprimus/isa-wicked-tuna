import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from './account/change-password/change-password.component';
import { EmailConfirmComponent } from './account/email-confirm/email-confirm.component';
import { LoginComponent } from './account/login/login.component';
import { EmailSentComponent } from './account/register/email-sent/email-sent.component';
import { RegisterClientComponent } from './account/register/register-client/register-client.component';
import { RegisterUserComponent } from './account/register/register-user/register-user.component';
import { RegisterComponent } from './account/register/register.component';
import { BoatReservationsComponent } from './boats/boat-reservations/boat-reservations.component';
import { BoatComponent } from './boats/boat/boat.component';
import { BoatsComponent } from './boats/boats.component';
import { ClientProfileComponent } from './client/client-profile/client-profile.component';
import { CottageReservationsComponent } from './cottages/cottage-reservations/cottage-reservations.component';
import { CottageComponent } from './cottages/cottage/cottage.component';
import { CottagesComponent } from './cottages/cottages.component';
import { HomeComponent } from './home/home.component';
import { SpecialOffersComponent } from './special-offers/special-offers.component';
import { RegistrationRequestsComponent } from './system-admin/registration-requests/registration-requests.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'register/client', component: RegisterClientComponent },
  { path: 'register/user', component: RegisterUserComponent },
  { path: 'register/email', component: EmailSentComponent },
  { path: 'email/confirm', component: EmailConfirmComponent },
  { path: 'client/profile', component: ClientProfileComponent, canActivate: [AuthGuard]},
  { path: 'password', component: ChangePasswordComponent, canActivate: [AuthGuard]},
  { path: 'cottages', component: CottagesComponent },
  { path: 'cottage/:id', component: CottageComponent },
  { path: 'boats', component: BoatsComponent },
  { path: 'boat/:id', component: BoatComponent },
  { path: 'special-offers', component: SpecialOffersComponent },
  { path: 'cottages/reservations', component: CottageReservationsComponent },
  { path: 'boats/reservations', component: BoatReservationsComponent },
  { path: 'registration/requests', component: RegistrationRequestsComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
