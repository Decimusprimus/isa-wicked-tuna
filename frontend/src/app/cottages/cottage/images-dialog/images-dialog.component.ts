import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-images-dialog',
  templateUrl: './images-dialog.component.html',
  styleUrls: ['./images-dialog.component.css'],
})
export class ImagesDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ImagesDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
  }

}
