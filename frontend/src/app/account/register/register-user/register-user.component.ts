import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_core/auth.service';
import { Registration } from 'src/app/_models/regstration';
import PasswordValidator from 'src/app/_validators/password-validator';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  submitted = false;
  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6), Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")]],
    repeatedPassword: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    phoneNumber: ['', [Validators.pattern('^[0-9]+$'), Validators.required]],
    country: ['', [Validators.required]],
    city: ['', [Validators.required]],
    street: ['', [Validators.required]],
    explanation: ['', [Validators.required]],
    userType: ['', [Validators.required]]
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
  explanation: AbstractControl;
  userType: AbstractControl;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
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
    this.explanation = this.form.controls['explanation'];
    this.userType = this.form.controls['userType'];
  }

  ngOnInit(): void {
  }


  onSubmit(): void{

    if (this.form.invalid) {
      return;
    }
    this.register();
  }

  getEmailErrorMessage() {
    if(this.email.hasError('required')) {
      return 'Email is required!';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  checkPasswordMatch(): boolean {
    if(this.password.value === this.repeatedPassword.value){
      return true
    } else {
      return false
    }
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

  register() {
    const regForm = new Registration();
    regForm.email = this.email.value;
    regForm.name = this.firstName.value;
    regForm.surname = this.lastName.value;
    regForm.password = this.password.value;
    regForm.passwordRepeated = this.repeatedPassword.value;
    regForm.phoneNumber = this.phoneNumber.value;
    regForm.country = this.country.value;
    regForm.city = this.city.value;
    regForm.streetName = this.street.value;
    regForm.explanation = this.explanation.value;
    regForm.role = this.userType.value;
    console.log(regForm);
    this.authService.registerUser(regForm).subscribe(res => {
      this.router.navigate(['/']);
    })
  }
}
