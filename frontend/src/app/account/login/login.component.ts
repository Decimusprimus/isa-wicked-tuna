import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService } from 'src/app/_core/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = this.formBuilder.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });
  email: AbstractControl;
  password: AbstractControl;
  loading = false;
  submitted = false;
  returnUrl = '';

  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) {
      this.email = this.loginForm.controls['email'];
      this.password = this.loginForm.controls['password'];
      if (this.authenticationService.userValue) {
        this.router.navigate(['/']);
      }
    }
  

  ngOnInit(): void {
    

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.loginForm.controls; }

  onSubmit(): void {
    this.submitted = true;

    this.loading = true;
        this.authenticationService.login(this.email.value, this.password.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.loading = false;
                });
  }

  reloadPage(): void {
    window.location.reload();
  }

  register(): void {
    this.router.navigate(['register']);
  }

  login(): void {
    this.authenticationService.login(this.email.value, this.password.value).subscribe(res => {
      this.router.navigate(['']);
    },
    error => {
      this.loading = false;
    })
  }


}
