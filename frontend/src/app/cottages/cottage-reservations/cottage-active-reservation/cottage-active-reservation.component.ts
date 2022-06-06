import { Component, Input, OnInit } from '@angular/core';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';
import { CottageReservation } from 'src/app/_models/cottageReservation';

@Component({
  selector: 'app-cottage-active-reservation',
  templateUrl: './cottage-active-reservation.component.html',
  styleUrls: ['./cottage-active-reservation.component.css']
})
export class CottageActiveReservationComponent implements OnInit {
  @Input() reservation = new CottageReservation();
  cottage = new Cottage();
  imgSrc = '';

  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.cottageService.getCottage(this.reservation.cottageId!).subscribe(data => {
      this.cottage = data;
      this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
    })
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

  cancelReservation() {
    this.cottageService.cancelReservation(this.reservation).subscribe(data=>{
      console.log(data);
    });
  }

}
