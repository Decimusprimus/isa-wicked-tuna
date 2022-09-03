import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService, UserService } from '../_core';
import { AuthService } from '../_core/auth.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  user: User;

  constructor(
    private authService: AuthenticationService,
    private userService: UserService,
    private router: Router,
    ) { 
    this.user = new User();
  }

  ngOnInit(): void {
    
  }

  goToHome() {
    this.router.navigate(['/']);
  }

  logout() {
    this.authService.logout();
  }

  clickMe() {
    console.log(this.userService.currentUser);
    console.log(this.userService.isUserPresent());
  }

}
