import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-system-admin-header',
  templateUrl: './system-admin-header.component.html',
  styleUrls: ['./system-admin-header.component.css']
})
export class SystemAdminHeaderComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  goToRegistrationRequest() {
    this.router.navigate(['registration/requests'])
  }

}
