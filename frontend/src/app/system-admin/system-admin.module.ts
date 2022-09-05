import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationRequestsComponent } from './registration-requests/registration-requests.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RegistrationRequestComponent } from './registration-requests/registration-request/registration-request.component';
import { DeclineDialogComponent } from './registration-requests/registration-request/decline-dialog/decline-dialog.component';



@NgModule({
  declarations: [
    RegistrationRequestsComponent,
    RegistrationRequestComponent,
    DeclineDialogComponent,
  ],
  exports: [
    RegistrationRequestsComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ]
})
export class SystemAdminModule { }
