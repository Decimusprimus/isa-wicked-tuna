import { Component, Input, OnInit } from '@angular/core';
import { CottageService } from 'src/app/_core/cottage.service';
import { Cottage } from 'src/app/_models/cottage';

@Component({
  selector: 'app-image-show-dialog',
  templateUrl: './image-show-dialog.component.html',
  styleUrls: ['./image-show-dialog.component.css']
})
export class ImageShowDialogComponent implements OnInit {
  @Input() image = '';
  @Input() cottage = new Cottage();
  imgSrc = '';

  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.imgSrc = this.cottageService.getCottageImageForName(this.cottage, this.image);
  }

  getImage() {
    this.cottageService.getCottageImageForName(this.cottage, this.image);
  }

}
