import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BoatService } from 'src/app/_core/boat.service';

@Component({
  selector: 'app-boat-images-dialog',
  templateUrl: './boat-images-dialog.component.html',
  styleUrls: ['./boat-images-dialog.component.css']
})
export class BoatImagesDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<BoatImagesDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
  }

  getImage(image: string) {
    return this.boatService.getBoatImageForName(this.data.boat, image);
  }

}
