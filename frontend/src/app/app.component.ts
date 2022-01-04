import { Component } from '@angular/core';
import { AuthenticationService } from './_core';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user!: User;

  constructor(private authenticationService: AuthenticationService) {
  }
}
