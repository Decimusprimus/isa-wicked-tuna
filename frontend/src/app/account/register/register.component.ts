import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    username: null,
    email: null,
    password: null
  };

  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(
    private router: Router,
    private authService: AuthenticationService
    ) { }

  ngOnInit(): void {
  }
  
  onSubmit(): void {
    
  }

  registerClient(): void {
    this.router.navigate(['register/client']);
  }

}
