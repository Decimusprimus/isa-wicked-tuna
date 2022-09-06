import { Component, OnInit } from '@angular/core';
import { BoatService } from 'src/app/_core/boat.service';
import { BoatReservation } from 'src/app/_models/boatResrvation';

@Component({
  selector: 'app-boat-reservations',
  templateUrl: './boat-reservations.component.html',
  styleUrls: ['./boat-reservations.component.css']
})
export class BoatReservationsComponent implements OnInit {
  pastReservations: BoatReservation[] = [];
  activeReservations: BoatReservation[] = [];

  constructor(
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.boatService.getPastReservations().subscribe(data => {
      this.pastReservations = data;
    })
    this.boatService.getActiveReservations().subscribe(data => {
      this.activeReservations = data;
    })
  }

}
