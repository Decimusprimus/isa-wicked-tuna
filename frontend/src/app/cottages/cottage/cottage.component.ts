import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';
import { CottageReservation } from 'src/app/_models/cottageReservation';
import { environment } from 'src/environments/environment';
import { ImagesDialogComponent } from './images-dialog/images-dialog.component';

@Component({
  selector: 'app-cottage',
  templateUrl: './cottage.component.html',
  styleUrls: ['./cottage.component.css']
})
export class CottageComponent implements OnInit {
  id: any;
  cottage: Cottage = new Cottage();
  imgSrc = '';
  images : string[] = [];
  addService = true;
  additionalServices: string[] = [];
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
    private cottageService: CottageService,
    public dialog: MatDialog,
    private formBuilder: FormBuilder,
    private authService: AuthenticationService,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    
      this.cottageService.getCottage(this.id).subscribe(data => {
        this.cottage = data;
        this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
        this.getAdditionalServices();
        console.log(this.cottage);
      })
      this.cottageService.getCottageImages(this.id).subscribe(data => {
        this.images = data;
      })
    })
  }

  getAddress() {
    return this.cottage.address.county + ', ' + this.cottage.address.city + ', ' + this.cottage.address.street;
  }

  getAdditionalServices() {
    if(this.cottage.additionalServices)
    {
      let a = this.cottage.additionalServices.split(',');
      a.forEach(el =>{
        this.additionalServices.push(el.trim());
      })
      return;
    }
    this.addService = false;
  }

  showImages() {
    this.dialog.open(ImagesDialogComponent, {
      minWidth: '400px',
      data: { cottage: this.cottage, images: this.images}
    });
  }

  dateTimeFilterFrom = (d: Date | null) : boolean => {
    const day = (d || new Date()).getTime();
    return this.checkDateFrom(day);
  }

  checkDateFrom(date: number) : boolean {
    var valid = false;
    if(this.reservationForm.get('myDatePickerTo')?.value  && this.reservationForm.get('myDatePickerTo')?.value.getTime() < date )
    {
      return false;
    }
    this.cottage.cottageAvailablePeriods.forEach(element => {
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
    if(this.reservationForm.get('myDatePickerFrom')?.value && this.reservationForm.get('myDatePickerFrom')?.value.getTime() > date )
    {
      return false;
    }
    this.cottage.cottageAvailablePeriods.forEach(element => {
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
    if(this.reservationForm.invalid)
    {
      return
    }
    var reservation = new CottageReservation();
    reservation.additionalServices = this.reservationForm.get('selectedAdditionalServices')?.value.toString();
    reservation.numberOfPeople = this.reservationForm.get('numberOfPeople')?.value;
    reservation.start = this.reservationForm.get('myDatePickerFrom')?.value;
    reservation.end = this.reservationForm.get('myDatePickerTo')?.value
    console.log(reservation);
    this.cottageService.crateReservation(reservation, this.cottage).subscribe({
      next: data =>
      {
        this.reservationCreated = true;
      },
      error: err => {
        this.validDates = false;
      }
    })
  }

}
