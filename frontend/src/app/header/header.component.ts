import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_core';
import { User } from '../_models/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  user: User;

  constructor(private authService: AuthenticationService) { 
    this.user = new User();
  }

  ngOnInit(): void {
    
  }

  logout() {
    this.authService.logout();
  }

}
