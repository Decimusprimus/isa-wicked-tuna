import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/_core';
import PasswordValidator from 'src/app/_validators/password-validator';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  form = this.formBuilder.group({
    oldPassword: ['', [Validators.required]],
    newPassword: ['', [Validators.required, Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$"), Validators.minLength(6)]],
    confirmNewPassword: ['', [Validators.required]]
  },
  {
    validators: [PasswordValidator.mustMatch('newPassword', 'confirmNewPassword')]
  })

  oldPassword: AbstractControl;
  newPassword: AbstractControl;
  confirmNewPassword: AbstractControl;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthenticationService,
  ) { 
    this.oldPassword = this.form.controls['oldPassword'];
    this.newPassword = this.form.controls['newPassword'];
    this.confirmNewPassword = this.form.controls['confirmNewPassword'];
  }

  ngOnInit(): void {
  }

  onSubmit(): void {

  }

  getPasswordErrorMessage() {
    if(this.newPassword.hasError('required')) {
      return 'Password is required!'
    } else if(this.newPassword.hasError('minLength')) {
      return 'Passwords must be at least six characters long!'
    } else if(this.newPassword.hasError('pattern')) {
      return 'Passwords must contain at least one uppercase letter, one lowercase letter, one number and one special character!';
    } 
    return '';
  }

}
