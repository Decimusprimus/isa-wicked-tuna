import { Component, Input, OnInit } from '@angular/core';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';
import { BoatReservation } from 'src/app/_models/boatResrvation';

@Component({
  selector: 'app-boat-past-reservation',
  templateUrl: './boat-past-reservation.component.html',
  styleUrls: ['./boat-past-reservation.component.css']
})
export class BoatPastReservationComponent implements OnInit {
  @Input() reservation = new BoatReservation();
  boat = new Boat();
  imgSrc = '';
  cancelled = false;

  constructor(
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.boatService.getBoat(this.reservation.boatId!).subscribe(data => {
      this.boat = data;
      this.imgSrc = this.boatService.getFirstBoatImage(this.boat);
      this.cancelled = this.reservation.reservationStatus == 1;
    })
  }
  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

}
