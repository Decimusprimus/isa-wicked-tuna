import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService, UserService } from 'src/app/_core';
import { AuthService } from 'src/app/_core/auth.service';

@Component({
  selector: 'app-authentication-button',
  templateUrl: './authentication-button.component.html',
  styleUrls: ['./authentication-button.component.css']
})
export class AuthenticationButtonComponent implements OnInit {

  constructor(
    public authService: AuthenticationService,
    public autService: AuthService,
    public userService: UserService,
    private router: Router,
    ) { }

  ngOnInit(): void {
  }

  logout(): void {
    /*this.authService.logout().subscribe(res => {
      this.router.navigate(['/']);
    });*/
    this.autService.logout().subscribe();
  }

  login(): void {
    this.router.navigate(['login']);
  }

  singUp() {
    this.router.navigate(['register']);
  }

  goToProfile(): void {
    this.router.navigate(['client/profile']);
  }

  goToChangePassword(): void {
    this.router.navigate(['password']);
  }

}
