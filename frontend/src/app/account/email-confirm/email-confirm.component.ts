import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_core';

@Component({
  selector: 'app-email-confirm',
  templateUrl: './email-confirm.component.html',
  styleUrls: ['./email-confirm.component.css']
})
export class EmailConfirmComponent implements OnInit {
  token = ''; //string | null;
  email = ''; // string | null;
  error = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.token = params['token'];
      this.email = params['email'];
      console.log(this.email);
      console.log(this.token);
      if(this.email != '' || this.token != '')
      {
        this.confirmEmail();
      }
      this.error = true;

      
    })
    // this.token = this.route.snapshot.paramMap.get('token');
    // this.email = this.route.snapshot.paramMap.get('email');
    // if(this.email == null || this.token == null)
    // {
    //   this.error = true;
    // }
      
  }

  private confirmEmail(): void {
    this.userService.confirmEmail(encodeURIComponent(this.token), this.email).subscribe(result =>{
      this.router.navigate(['/login']);
    })
  }

}
