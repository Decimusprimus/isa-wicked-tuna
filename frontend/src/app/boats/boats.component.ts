import { Component, OnInit } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';
import { BoatService } from '../_core/boat.service';
import { Boat } from '../_models/boat';

@Component({
  selector: 'app-boats',
  templateUrl: './boats.component.html',
  styleUrls: ['./boats.component.css'],
  viewProviders: [MatExpansionPanel]
})
export class BoatsComponent implements OnInit {
  boats: Boat[] = [];

  constructor(
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.getBoats();
  }

  getBoats(): void {
    this.boatService.getBoats().subscribe(data => this.boats = data);
  }

}
