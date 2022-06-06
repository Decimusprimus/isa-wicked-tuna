import { Component, Input, OnInit } from '@angular/core';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';
import { CottageReservation } from 'src/app/_models/cottageReservation';

@Component({
  selector: 'app-cottage-past-reservation',
  templateUrl: './cottage-past-reservation.component.html',
  styleUrls: ['./cottage-past-reservation.component.css']
})
export class CottagePastReservationComponent implements OnInit {
  @Input() reservation = new CottageReservation();
  cottage = new Cottage();
  imgSrc = '';
  cancelled = false;

  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.cottageService.getCottage(this.reservation.cottageId!).subscribe(data => {
      this.cottage = data;
      this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
      this.cancelled = new Date(this.reservation.start).getTime() > new Date().getTime();
    })
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

}
