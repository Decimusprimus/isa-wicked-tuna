import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';

@Component({
  selector: 'app-boat-item',
  templateUrl: './boat-item.component.html',
  styleUrls: ['./boat-item.component.css']
})
export class BoatItemComponent implements OnInit {
  @Input() boat = new Boat();
  imgSrc = '';

  constructor(
    private router: Router,
    private boatService : BoatService,
  ) { }

  ngOnInit(): void {
    this.imgSrc = this.boatService.getFirstBoatImage(this.boat);
  }

  getAddress() {
    return this.boat.address.county + ', ' + this.boat.address.city + ', ' + this.boat.address.street;
  }

  goToBoat() {
    this.router.navigate(['boat', this.boat.id]);
  }

}
