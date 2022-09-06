import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';
import { BoatReservation } from 'src/app/_models/boatResrvation';
import { BoatImagesDialogComponent } from './boat-images-dialog/boat-images-dialog.component';

@Component({
  selector: 'app-boat',
  templateUrl: './boat.component.html',
  styleUrls: ['./boat.component.css']
})
export class BoatComponent implements OnInit {
  id: any;
  boat: Boat = new Boat();
  imgSrc = '';
  images: string[] = [];
  failedToLoad = false;
  reservationForm = this.formBuilder.group({
    selectedAdditionalServices: '',
    myDatePickerFrom : '',
    myDatePickerTo: '',
    numberOfPeople: ['', [Validators.pattern('^[0-9]+$'), Validators.required]],
  });
  validDates = true;
  reservationCreated = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private boatService: BoatService,
    public dialog: MatDialog,
    private formBuilder: FormBuilder,
    private authService: AuthenticationService,
  ) { }

  ngOnInit(): void {
    this.getBoat()
  }

  getBoat() {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');

      this.boatService.getBoat(this.id).subscribe({
        next: data => {
          this.boat = data;
          this.imgSrc = this.boatService.getFirstBoatImage(this.boat);
          this.failedToLoad = false;
        },
        error: err => {
          this.failedToLoad = true;
        }
      })
      this.boatService.getBoatImages(this.id).subscribe( data => {
        this.images = data;
      })
    })
  }

  getAddress() {
    return this.boat.address.county + ', ' + this.boat.address.city + ', ' + this.boat.address.street;
  }

  showImages() {
    this.dialog.open(BoatImagesDialogComponent, {
      data: { boat: this.boat, images: this.images}
    });
  }

  dateTimeFilterFrom = (d: Date | null) : boolean => {
    const day = (d || new Date()).getTime();
    return this.checkDateFrom(day);
  }

  checkDateFrom(date: number) : boolean {
    var valid = false;
    this.boat.boatAvailablePeriods.forEach(element => {
      let startDate = new Date(element.start).getTime();
      let endDate = new Date(element.end).getTime();
      let today = new Date().getTime();
      if(date >= startDate && date <= endDate && date >= today)
      {
        valid = true;
      }
    });
    return valid;
  }

  dateTimeFilterTo = (d: Date | null) : boolean => {
    const day = (d || new Date()).getTime();
    return this.checkDateFrom(day);
  }

  checkDateTo(date: number) : boolean {
    var valid = false;
    this.boat.boatAvailablePeriods.forEach(element => {
      let startDate = new Date(element.start).getTime();
      let endDate = new Date(element.end).getTime();
      let today = new Date().getTime();
      if(date >= startDate && date <= endDate && date >= today)
      {
        valid = true;
      }
    });
    return valid;
  }

  makeReservation() {
    if(!this.authService.getJwtToken())
    {
      this.router.navigate(['login']);
      return;
    }
    if(this.reservationForm.get('myDatePickerFrom')?.value === null || this.reservationForm.get('myDatePickerTo')?.value === null) {
      this.validDates == false;
    }
    if(this.reservationForm.invalid)
    {
      return
    }
    var reservation = new BoatReservation();
    reservation.boatReservationOptions =  this.reservationForm.get('selectedAdditionalServices')?.value;
    reservation.numberOfPeople = this.reservationForm.get('numberOfPeople')?.value;
    reservation.start = this.reservationForm.get('myDatePickerFrom')?.value;
    reservation.end = this.reservationForm.get('myDatePickerTo')?.value
    console.log(reservation);
    console.log(this.boat.id);
    this.boatService.createReservation(reservation, this.boat).subscribe({
      next: data =>
      {
        this.reservationCreated = true;
        window.alert('Reservation created!')
      },
      error: err => {
        if(err.error === 'RegistrationException') {
          window.alert('You cannot make reservation on same entity in same period twice!');
        } else if (err.error === 'Dates incorect!') {
          this.validDates = false;
        }else if (err.error === 'Already reserved!') {
          this.validDates = false;
          this.getBoat();
          window.alert('It is already reserved!');
        } else {
          window.alert('Something went wrong!');
        }
      }
    })
  }


}
