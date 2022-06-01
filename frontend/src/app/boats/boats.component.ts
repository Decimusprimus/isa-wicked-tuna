import { Component, OnInit } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';

@Component({
  selector: 'app-boats',
  templateUrl: './boats.component.html',
  styleUrls: ['./boats.component.css'],
  viewProviders: [MatExpansionPanel]
})
export class BoatsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
