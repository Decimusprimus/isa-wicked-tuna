import { Component, Input, OnInit } from '@angular/core';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';
import { BoatReservation } from 'src/app/_models/boatResrvation';

@Component({
  selector: 'app-boat-offer',
  templateUrl: './boat-offer.component.html',
  styleUrls: ['./boat-offer.component.css']
})
export class BoatOfferComponent implements OnInit {
  @Input() boatOffer = new BoatReservation();
  boat = new Boat();
  imgSrc = '';

  constructor(
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.boatService.getBoat(this.boatOffer.boatId!).subscribe(data => {
      this.boat = data;
      this.imgSrc = this.boatService.getFirstBoatImage(this.boat);
    })
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

  confirmOffer() {
    this.boatService.confirmSpecialOffer(this.boatOffer).subscribe({
      next: data => {
        console.log(data);
        window.alert('Reservation made!')
      },
      error: err => {
        if(err.error === 'RegistrationException') {
          window.alert('You cannot make reservation on same entity in same period twice!');
        } else {
          window.alert('Something went wrong!');
        }
      },
      complete: () => window.location.reload()
    })
  }

}
