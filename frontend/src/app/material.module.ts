import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input'; 
import { MatFormFieldModule } from '@angular/material/form-field'; 
import {MatIconModule} from '@angular/material/icon'; 
import {MatMenuModule} from '@angular/material/menu'; 
import {MatExpansionModule} from '@angular/material/expansion'; 
import {MatDividerModule} from '@angular/material/divider'; 
import {MatDialogModule} from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatListModule} from '@angular/material/list'; 
import {MatTabsModule} from '@angular/material/tabs'; 
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';
import {MatSelectModule} from '@angular/material/select';


@NgModule({
  imports: [
    MatInputModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatMenuModule,
    MatExpansionModule,
    MatDividerModule,
    MatDialogModule,
    MatDatepickerModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    NgxMatTimepickerModule,
    MatListModule,
    MatTabsModule,
    MatSelectModule
  ],
  exports: [
    MatInputModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,  
    MatMenuModule,  
    MatExpansionModule,
    MatDividerModule,
    MatDialogModule,
    MatDatepickerModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    NgxMatTimepickerModule,
    MatListModule,
    MatTabsModule,
    MatSelectModule
  ]
})
export class MaterialModule { }
