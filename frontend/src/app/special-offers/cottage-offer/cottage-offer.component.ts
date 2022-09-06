import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';
import { CottageReservation } from 'src/app/_models/cottageReservation';

@Component({
  selector: 'app-cottage-offer',
  templateUrl: './cottage-offer.component.html',
  styleUrls: ['./cottage-offer.component.css']
})
export class CottageOfferComponent implements OnInit {
  @Input() cottageOffer = new CottageReservation();
  cottage = new Cottage();
  imgSrc = '';

  constructor(
    private cottageService: CottageService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.getOffers();
  }

  getOffers() {
    this.cottageService.getCottage(this.cottageOffer.cottageId!).subscribe(data => {
      this.cottage = data;
      this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
    })
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

  confirmOffer() {
    this.cottageService.confirmSpecialOffer(this.cottageOffer).subscribe({
      next: data => {
        console.log(data);
        window.alert('Reservation made!')
      },
      error: err => {
        if(err.error === 'RegistrationException') {
          window.alert('You cannot make reservation on same entity in same period twice!');
        } else if (err.error === 'Already reserved!'){
          window.alert('Already reserved!');
          this.getOffers();
        } else {
          window.alert('Something went wrong!');
        }
      },
      complete: () => window.location.reload()
    })
  }

}
