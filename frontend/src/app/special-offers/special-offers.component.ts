import { Component, OnInit } from '@angular/core';
import { BoatService } from 'src/app/_core/boat.service';
import { CottageService } from 'src/app/_core/cottage.service';
import { BoatReservation } from 'src/app/_models/boatResrvation';
import { CottageReservation } from 'src/app/_models/cottageReservation';

@Component({
  selector: 'app-special-offers',
  templateUrl: './special-offers.component.html',
  styleUrls: ['./special-offers.component.css']
})
export class SpecialOffersComponent implements OnInit {
  cottageSpecialOffers: CottageReservation[] = [];
  boatSpecialOffers: BoatReservation[] = [];

  constructor(
    private cottageService: CottageService,
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.getCottageSpecialOffers();
    this.getBoatSpecialOffers();
  }

  getCottageSpecialOffers(){
    this.cottageService.getSpecialOffers().subscribe(
      data => {
        this.cottageSpecialOffers = data;
      }
    )
  }

  getBoatSpecialOffers() {
    this.boatService.getSpecialOffers().subscribe(
      data => {
        this.boatSpecialOffers = data;
      }
    )
  }

}
