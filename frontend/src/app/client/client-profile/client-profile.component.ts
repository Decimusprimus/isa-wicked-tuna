import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';
import PasswordValidator from 'src/app/_validators/password-validator';

@Component({
  selector: 'app-client-profile',
  templateUrl: './client-profile.component.html',
  styleUrls: ['./client-profile.component.css']
})
export class ClientProfileComponent implements OnInit {
  
  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6), Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]],
    repeatedPassword: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    phoneNumber: ['', [Validators.pattern('^[0-9]+$'), Validators.required]],
    country: ['', [Validators.required]],
    city: ['', [Validators.required]],
    street: ['', [Validators.required]]
  },
  {
   validators: [PasswordValidator.mustMatch('password', 'repeatedPassword')]
  }
  );

  email: AbstractControl;
  password: AbstractControl;
  firstName: AbstractControl;
  lastName: AbstractControl;
  repeatedPassword: AbstractControl;
  phoneNumber: AbstractControl;
  country: AbstractControl;
  city: AbstractControl;
  street: AbstractControl;


  constructor(
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
    this.email = this.form.controls['email'];
    this.password = this.form.controls['password'];
    this.firstName = this.form.controls['firstName'];
    this.lastName = this.form.controls['lastName'];
    this.repeatedPassword = this.form.controls['repeatedPassword'];
    this.phoneNumber = this.form.controls['phoneNumber'];
    this.country = this.form.controls['country'];
    this.city = this.form.controls['city'];
    this.street = this.form.controls['street'];
   }

  ngOnInit(): void {
  }

  onSubmit(): void{
    
  }

  getEmailErrorMessage() {
    if(this.email.hasError('required')) {
      return 'Email is required!';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  getPasswordErrorMessage() {
    if(this.password.hasError('required')) {
      return 'Password is required!'
    } else if(this.password.hasError('minLength')) {
      return 'Passwords must be at least six characters long!'
    } else if(this.password.hasError('pattern')) {
      return 'Passwords must contain at least one uppercase letter, one lowercase letter, one number and one special character!';
    } 
    return '';
  }

}
