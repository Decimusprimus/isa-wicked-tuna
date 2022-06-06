import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CottagesComponent } from './cottages.component';
import { CottageItemComponent } from './cottage-item/cottage-item.component';
import { CottageComponent } from './cottage/cottage.component';
import { ImagesDialogComponent } from './cottage/images-dialog/images-dialog.component';
import { ImageShowDialogComponent } from './cottage/images-dialog/image-show-dialog/image-show-dialog.component';
import { CottageReservationsComponent } from './cottage-reservations/cottage-reservations.component';
import { CottageActiveReservationComponent } from './cottage-reservations/cottage-active-reservation/cottage-active-reservation.component';
import { CottagePastReservationComponent } from './cottage-reservations/cottage-past-reservation/cottage-past-reservation.component';



@NgModule({
  declarations: [
    CottagesComponent,
    CottageItemComponent,
    CottageComponent,
    ImagesDialogComponent,
    ImageShowDialogComponent,
    CottageReservationsComponent,
    CottageActiveReservationComponent,
    CottagePastReservationComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports: [
    CottagesComponent,
    CottageComponent
  ],
})
export class CottagesModule { }
