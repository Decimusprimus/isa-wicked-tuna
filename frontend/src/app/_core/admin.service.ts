import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(
    private http: HttpClient,
  ) { }

    getRequestToReview() {
      return this.http.get<any>(`${environment.apiUrl}/api/registration/toreview`);
    }

}
