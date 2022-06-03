import { Component, OnInit } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';
import { CottageService } from '../_core/cottage.service';
import { Cottage } from '../_models/cottage';

@Component({
  selector: 'app-cottages',
  templateUrl: './cottages.component.html',
  styleUrls: ['./cottages.component.css'],
  viewProviders: [MatExpansionPanel]
})
export class CottagesComponent implements OnInit {
  cottages: Cottage[] = [];
  constructor(
    private cottageService: CottageService,
  ) { }

  ngOnInit(): void {
    this.getCottages();
  }

  getCottages(): void {
    this.cottageService.getCottages().subscribe(data => this.cottages = data);
  }

}
