import { Component, Input, OnInit } from '@angular/core';
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
    private cottageService: CottageService
  ) { }

  ngOnInit(): void {
    
    this.cottageService.getCottage(this.cottageOffer.cottageId).subscribe(data => {
      this.cottage = data;
      this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
    })
    
  }

  getDatTimeString(date: Date){
    let d = new Date(date);
    return d.toString().substring(0,15);
  }

}
