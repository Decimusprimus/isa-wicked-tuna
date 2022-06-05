import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';
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
  myDatePickerFrom = new FormControl('');
  myDatePickerTo = new FormControl('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private boatService: BoatService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
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

  dateTimeFilter = (d: Date | null) : boolean => {
    const day = (d || new Date()).getTime();
    return this.checkDate(day);
  }

  checkDate(date: number) : boolean {
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
    console.log(this.myDatePickerFrom);
  }


}
