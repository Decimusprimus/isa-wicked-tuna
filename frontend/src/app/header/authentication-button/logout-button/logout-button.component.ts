import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';

@Component({
  selector: 'app-logout-button',
  templateUrl: './logout-button.component.html',
  styleUrls: ['./logout-button.component.css']
})
export class LogoutButtonComponent implements OnInit {

  constructor(
    private router: Router,
    private authService: AuthenticationService) { }

  ngOnInit(): void {
  }


  logout(): void {
    this.authService.logout().subscribe(res => {
      this.router.navigate(['/']);
    });
  }

}
