import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CottageOfferComponent } from './cottage-offer/cottage-offer.component';
import { BoatOfferComponent } from './boat-offer/boat-offer.component';
import { SpecialOffersComponent } from './special-offers.component';



@NgModule({
  declarations: [
    SpecialOffersComponent,
    CottageOfferComponent,
    BoatOfferComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports: [
    SpecialOffersComponent
  ]
})
export class SpecialOffersModule { }
