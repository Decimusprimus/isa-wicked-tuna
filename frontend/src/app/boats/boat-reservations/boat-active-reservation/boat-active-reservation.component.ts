import { Component, Input, OnInit } from '@angular/core';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';
import { BoatReservation } from 'src/app/_models/boatResrvation';

@Component({
  selector: 'app-boat-active-reservation',
  templateUrl: './boat-active-reservation.component.html',
  styleUrls: ['./boat-active-reservation.component.css']
})
export class BoatActiveReservationComponent implements OnInit {
  @Input() reservation = new BoatReservation();
  boat = new Boat();
  imgSrc = '';
  disabled = false;

  constructor(
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.checkReservationDate();
    this.boatService.getBoat(this.reservation.boatId!).subscribe(data => {
      this.boat = data;
      this.imgSrc = this.boatService.getFirstBoatImage(this.boat);
    })
  }

  checkReservationDate() {
    let today = new Date();
    let day = new Date(today.getTime());
    day.setDate(day.getDate() + 3);
    
    let startDate = new Date(this.reservation.start).getTime();
    if(startDate < day.getTime()){
      this.disabled = true;
    } else {
      this.disabled = false;
    }
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

  cancelReservation() {
    this.boatService.cancelReservation(this.reservation).subscribe({
      next: data=>{
        console.log(data);
        window.alert('Reservation cancelled!')
        window.location.reload();
      },
      error: err => {
        window.alert('Something went wrong!')
      }
    })
  }

}
