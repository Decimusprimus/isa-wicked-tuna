import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_core';
import { UserInformation } from 'src/app/_models/userInformation';
import PasswordValidator from 'src/app/_validators/password-validator';

@Component({
  selector: 'app-client-profile',
  templateUrl: './client-profile.component.html',
  styleUrls: ['./client-profile.component.css']
})
export class ClientProfileComponent implements OnInit {
  
  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
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
  firstName: AbstractControl;
  lastName: AbstractControl;
  phoneNumber: AbstractControl;
  country: AbstractControl;
  city: AbstractControl;
  street: AbstractControl;
  id = '';


  constructor(
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
    this.email = this.form.controls['email'];
    this.firstName = this.form.controls['firstName'];
    this.lastName = this.form.controls['lastName'];
    this.phoneNumber = this.form.controls['phoneNumber'];
    this.country = this.form.controls['country'];
    this.city = this.form.controls['city'];
    this.street = this.form.controls['street'];
   }

  ngOnInit(): void {
    this.authService.getUserInfo().subscribe(
      data => {
        console.log(data);
        this.id = data.id;
        this.form.patchValue({
          email : data.email,
          firstName : data.name,
          lastName: data.surname,
          country : data.county,
          city : data.city,
          street : data.streetName,
          phoneNumber : data.phoneNumber,
        })
        /*this.email.setValue(data.email);
        this.firstName.setValue(data.name);
        this.lastName.setValue(data.surname);
        this.country.setValue(data.county);
        this.city.setValue(data.city);
        this.street.setValue(data.streetName);
        this.phoneNumber.setValue(data.phoneNumber);*/
      }
    )
  }

  onSubmit(): void{
    console.log(this.form.valid);
    this.form.updateValueAndValidity();
    if (this.form.invalid) {
      console.log(this.form.errors)
      return;
    }
    
    let userInfo = new UserInformation();
    userInfo.id = this.id;
    userInfo.email = this.email.value;
    userInfo.name = this.firstName.value;
    userInfo.surname = this.lastName.value;
    userInfo.county = this.country.value;
    userInfo.city = this.city.value;
    userInfo.streetName = this.street.value;
    userInfo.phoneNumber  = this.phoneNumber.value;
    this.authService.updateUserInformation(userInfo).subscribe({
      next: data => {
        console.log(data);
        this.email.setValue(data.email);
        this.firstName.setValue(data.name);
        this.lastName.setValue(data.surname);
        this.country.setValue(data.county);
        this.city.setValue(data.city);
        this.street.setValue(data.streetName);
        this.phoneNumber.setValue(data.phoneNumber);
      },
      error: error => {
        window.alert("Couldn't update user information!");
      }
    })
    
  }

  getEmailErrorMessage() {
    if(this.email.hasError('required')) {
      return 'Email is required!';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
}
