import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoatsComponent } from './boats.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BoatItemComponent } from './boat-item/boat-item.component';
import { BoatComponent } from './boat/boat.component';
import { BoatImagesDialogComponent } from './boat/boat-images-dialog/boat-images-dialog.component';
import { BoatActiveReservationComponent } from './boat-reservations/boat-active-reservation/boat-active-reservation.component';
import { BoatPastReservationComponent } from './boat-reservations/boat-past-reservation/boat-past-reservation.component';
import { BoatReservationsComponent } from './boat-reservations/boat-reservations.component';



@NgModule({
  declarations: [
    BoatsComponent,
    BoatItemComponent,
    BoatComponent,
    BoatImagesDialogComponent,
    BoatActiveReservationComponent,
    BoatPastReservationComponent,
    BoatReservationsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports:[
    BoatsComponent,
    BoatComponent,
    BoatReservationsComponent
  ]
})
export class BoatsModule { }
