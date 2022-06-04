import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoatsComponent } from './boats.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BoatItemComponent } from './boat-item/boat-item.component';
import { BoatComponent } from './boat/boat.component';



@NgModule({
  declarations: [
    BoatsComponent,
    BoatItemComponent,
    BoatComponent
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
    BoatComponent
  ]
})
export class BoatsModule { }
