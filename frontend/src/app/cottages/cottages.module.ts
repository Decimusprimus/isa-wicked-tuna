import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CottagesComponent } from './cottages.component';
import { CottageItemComponent } from './cottage-item/cottage-item.component';



@NgModule({
  declarations: [
    CottagesComponent,
    CottageItemComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports: [],
})
export class CottagesModule { }
