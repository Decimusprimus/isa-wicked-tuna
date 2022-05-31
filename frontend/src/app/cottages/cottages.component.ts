import { Component, OnInit } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';

@Component({
  selector: 'app-cottages',
  templateUrl: './cottages.component.html',
  styleUrls: ['./cottages.component.css'],
  viewProviders: [MatExpansionPanel]
})
export class CottagesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
