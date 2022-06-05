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



@NgModule({
  declarations: [
    CottagesComponent,
    CottageItemComponent,
    CottageComponent,
    ImagesDialogComponent,
    ImageShowDialogComponent,
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
