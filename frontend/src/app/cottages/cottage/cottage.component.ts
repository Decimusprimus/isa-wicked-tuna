import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';

@Component({
  selector: 'app-cottage',
  templateUrl: './cottage.component.html',
  styleUrls: ['./cottage.component.css']
})
export class CottageComponent implements OnInit {
  id: any;
  cottage: Cottage = new Cottage();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    
      this.cottageService.getCottage(this.id).subscribe(data => {
        this.cottage = data;
        console.log(this.cottage);
      })
    })
  }

  getAddress() {
    return this.cottage.address.county + ', ' + this.cottage.address.city + ', ' + this.cottage.address.street;
  }

}
