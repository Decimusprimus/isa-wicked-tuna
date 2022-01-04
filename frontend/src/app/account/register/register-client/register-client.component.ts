import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/_core';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css']
})
export class RegisterClientComponent implements OnInit {
  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    repeatedPassword: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
  });
  email: AbstractControl;
  password: AbstractControl;
  firstName: AbstractControl;
  lastName: AbstractControl;
  repeatedPassword: AbstractControl;

  constructor(
    private authService: AuthenticationService,
    private formBuilder: FormBuilder
  ) { 
    this.email = this.form.controls['email'];
    this.password = this.form.controls['password'];
    this.firstName = this.form.controls['firstName'];
    this.lastName = this.form.controls['lastName'];
    this.repeatedPassword = this.form.controls['repeatedPassword'];
  }

  ngOnInit(): void {
  }

  onSubmit(): void{
    console.log(this.email.value);
  }

  getEmailErrorMessage() {
    if(this.email.hasError('required')) {
      return 'Email is required!';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

}
