import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoatsComponent } from './boats.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BoatItemComponent } from './boat-item/boat-item.component';



@NgModule({
  declarations: [
    BoatsComponent,
    BoatItemComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports:[
    BoatsComponent
  ]
})
export class BoatsModule { }
