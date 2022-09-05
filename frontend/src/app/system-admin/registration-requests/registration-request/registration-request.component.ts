import { Component, Input, OnInit } from '@angular/core';
import { RegistrationRequest } from 'src/app/_models/registrationRequests';

@Component({
  selector: 'app-registration-request',
  templateUrl: './registration-request.component.html',
  styleUrls: ['./registration-request.component.css']
})
export class RegistrationRequestComponent implements OnInit {
  @Input() request = new RegistrationRequest();

  constructor() { }

  ngOnInit(): void {
  }

}
