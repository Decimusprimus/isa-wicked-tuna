import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  confirmEmail(token: string, email: string): Observable<boolean> {
    return this.http.get<any>(`${environment.apiUrl}/mail?token=${token}&email=${email}`);
  }
}
