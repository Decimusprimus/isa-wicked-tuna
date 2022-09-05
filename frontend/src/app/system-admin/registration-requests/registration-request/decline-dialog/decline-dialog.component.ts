import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-decline-dialog',
  templateUrl: './decline-dialog.component.html',
  styleUrls: ['./decline-dialog.component.css']
})
export class DeclineDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DeclineDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
  }

}
