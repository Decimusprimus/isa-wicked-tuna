import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CurrentUser } from '../_models/currentUser';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public currentUser = new CurrentUser();

  constructor(
    private http: HttpClient,
    ) { 

  }

  setupUser(username: string, role: string) {
    this.currentUser.username = username;
    this.currentUser.userRole = role;
  }

  removeUser() {
    this.currentUser.username = '';
    this.currentUser.userRole = '';
  }

  isUserPresent() {
    if(this.currentUser.username) {
      return true;
    }
    return false;
  }

  confirmEmail(token: string, email: string): Observable<boolean> {
    return this.http.get<any>(`${environment.apiUrl}/mail?token=${token}&email=${email}`);
  }
}
