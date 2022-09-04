import { Component, OnInit } from '@angular/core';
import { UserService } from '../_core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isSystemAdmin = false;
  constructor(private userService: UserService) { 

  }

  ngOnInit(): void {
    if(this.userService.currentUser.userRole !== 'SystemAdmin') {
      this.isSystemAdmin = false;
    } else { 
      this.isSystemAdmin = true;
    }
  }

}
