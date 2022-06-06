import { Component, OnInit } from '@angular/core';
import { CottageService } from 'src/app/_core/cottage.service';
import { CottageReservation } from 'src/app/_models/cottageReservation';

@Component({
  selector: 'app-cottage-reservations',
  templateUrl: './cottage-reservations.component.html',
  styleUrls: ['./cottage-reservations.component.css']
})
export class CottageReservationsComponent implements OnInit {
  pastReservations: CottageReservation[] = [];
  activeReservations: CottageReservation[] = [];

  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.cottageService.getPastReservations().subscribe(data => {
      this.pastReservations = data;
    })
    this.cottageService.getActiveReservations().subscribe(data => {
      this.activeReservations = data
    })
  }

}
