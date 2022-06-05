import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cottage } from 'src/app/_models/cottage';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cottage-item',
  templateUrl: './cottage-item.component.html',
  styleUrls: ['./cottage-item.component.css']
})
export class CottageItemComponent implements OnInit {
  @Input() cottage = new Cottage();
  imageSrc = '';

  constructor(
    private router: Router,

  ) { }

  ngOnInit(): void {
    this.imageSrc = `${environment.apiUrl}/cottages/${this.cottage.id}/image`;
  }

  getAddress() {
    return this.cottage.address.county + ', ' + this.cottage.address.city + ', ' + this.cottage.address.street;
  }

  goToCottage() {
    this.router.navigate(['cottage', this.cottage.id]);
  }
}
