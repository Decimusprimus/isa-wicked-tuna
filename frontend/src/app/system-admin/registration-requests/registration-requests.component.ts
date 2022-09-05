import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_core/admin.service';
import { RegistrationRequest } from 'src/app/_models/registrationRequests';

@Component({
  selector: 'app-registration-requests',
  templateUrl: './registration-requests.component.html',
  styleUrls: ['./registration-requests.component.css']
})
export class RegistrationRequestsComponent implements OnInit {
  requests: RegistrationRequest[] = [];
  selectedRequest = new RegistrationRequest();

  constructor(
    private adminService: AdminService,
  ) { }

  ngOnInit(): void {
    this.getRequests();
  }

  getRequests() {
    this.adminService.getRequestToReview().subscribe(data => this.requests = data);
  }

  onSelect(selected: RegistrationRequest) {
    this.selectedRequest = selected;
  }

}
