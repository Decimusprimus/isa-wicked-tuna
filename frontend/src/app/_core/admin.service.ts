import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RegistrationRequest } from '../_models/registrationRequests';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(
    private http: HttpClient,
  ) { }

    getRequestToReview() : Observable<RegistrationRequest[]> {
      return this.http.get<any>(`${environment.apiUrl}/registration/toreview`);
    }

}
