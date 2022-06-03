import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cottage } from 'src/app/_models/cottage';

@Component({
  selector: 'app-cottage-item',
  templateUrl: './cottage-item.component.html',
  styleUrls: ['./cottage-item.component.css']
})
export class CottageItemComponent implements OnInit {
  @Input() cottage = new Cottage();

  constructor(
    private router: Router,

  ) { }

  ngOnInit(): void {
  }

  getAddress() {
    return this.cottage.address.county + ', ' + this.cottage.address.city + ', ' + this.cottage.address.street;
  }

}
