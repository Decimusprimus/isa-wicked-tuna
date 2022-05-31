import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientHomeComponent } from './client-home/client-home.component';
import { MaterialModule } from '../material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './home.component';



@NgModule({
  declarations: [
    ClientHomeComponent,
    HomeComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule,
  ],
  exports: [
    HomeComponent,
  ]
})
export class HomeModule { }
