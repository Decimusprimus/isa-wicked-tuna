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
  disabled = false;

  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.checkReservationDate();
    this.cottageService.getCottage(this.reservation.cottageId!).subscribe(data => {
      this.cottage = data;
      this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
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
    this.cottageService.cancelReservation(this.reservation).subscribe(data=>{
      console.log(data);
    });
  }

}
