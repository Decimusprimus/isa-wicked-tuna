import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';
import { environment } from 'src/environments/environment';
import { ImagesDialogComponent } from './images-dialog/images-dialog.component';

@Component({
  selector: 'app-cottage',
  templateUrl: './cottage.component.html',
  styleUrls: ['./cottage.component.css']
})
export class CottageComponent implements OnInit {
  id: any;
  cottage: Cottage = new Cottage();
  imgSrc = '';
  images : string[] = [];
  myDatePickerFrom = new FormControl('');
  myDatePickerTo = new FormControl('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cottageService: CottageService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    
      this.cottageService.getCottage(this.id).subscribe(data => {
        this.cottage = data;
        this.imgSrc = this.cottageService.getFirstCottageImage(this.cottage);
        console.log(this.cottage);
      })
      this.cottageService.getCottageImages(this.id).subscribe(data => {
        this.images = data;
      })
    })
  }

  getAddress() {
    return this.cottage.address.county + ', ' + this.cottage.address.city + ', ' + this.cottage.address.street;
  }

  showImages() {
    this.dialog.open(ImagesDialogComponent, {
      minWidth: '400px',
      data: { cottage: this.cottage, images: this.images}
    });
  }

  dateTimeFilter = (d: Date | null) : boolean => {
    const day = (d || new Date()).getTime();
    return this.checkDate(day);
  }

  checkDate(date: number) : boolean {
    var valid = false;
    this.cottage.cottageAvailablePeriods.forEach(element => {
      let startDate = new Date(element.start).getTime();
      let endDate = new Date(element.end).getTime();
      let today = new Date().getTime();
      if(date >= startDate && date <= endDate && date >= today)
      {
        valid = true;
      }
    });
    return valid;
  }

}
