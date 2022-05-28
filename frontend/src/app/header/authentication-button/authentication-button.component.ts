import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';

@Component({
  selector: 'app-authentication-button',
  templateUrl: './authentication-button.component.html',
  styleUrls: ['./authentication-button.component.css']
})
export class AuthenticationButtonComponent implements OnInit {

  constructor(
    public authService: AuthenticationService,
    private router: Router,
    ) { }

  ngOnInit(): void {
  }

  logout(): void {
    this.authService.logout().subscribe(res => {
      this.router.navigate(['/']);
    });
  }

  login(): void {
    this.router.navigate(['login']);
  }

  goToProfile(): void {
    this.router.navigate(['client/profile']);
  }

  goToChangePassword(): void {
    this.router.navigate(['password']);
  }

}
