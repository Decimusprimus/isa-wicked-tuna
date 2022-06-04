import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BoatService } from 'src/app/_core/boat.service';
import { Boat } from 'src/app/_models/boat';

@Component({
  selector: 'app-boat',
  templateUrl: './boat.component.html',
  styleUrls: ['./boat.component.css']
})
export class BoatComponent implements OnInit {
  id: any;
  boat: Boat = new Boat();
  failedToLoad = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private boatService: BoatService,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');

      this.boatService.getBoat(this.id).subscribe({
        next: data => {
          this.boat = data;
          this.failedToLoad = false;
        },
        error: err => {
          this.failedToLoad = true;
        }
      })
    })
  }

  getAddress() {
    return this.boat.address.county + ', ' + this.boat.address.city + ', ' + this.boat.address.street;
  }

}
