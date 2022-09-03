import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ChangePassword } from '../_models/changePassword';
import { RegistrationForm } from '../_models/registrationForm';
import { User } from '../_models/user';
import { UserInformation } from '../_models/userInformation';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';

  constructor(
    private http: HttpClient,
    private userService: UserService,
    private router: Router,
    ) { 
      if(this.getRefreshToken()) {
        this.refreshToken();
      }
    }

  login(username: string, password: string) {
    return this.http.post<any>(`${environment.apiUrl}/auth/login`, {username, password})
    .pipe(map((res) => {
      console.log('Login successful');
      this.doLoginUser(res);
      this.userService.setupUser(res.username, res.userRole);
    }))
  }

  logout() {
    return this.http.post<any>(`${environment.apiUrl}/auth/revoke-token`, {
      'token': this.getRefreshToken()
    })
    .pipe(map((res) => {
      console.log('Token revoked');
      this.doLogoutUser();
      this.userService.removeUser();
      this.router.navigate(['/login']);
    })) 
    .pipe(catchError(err => this.checkError(err)));
  }

  refreshToken() {
    return this.http.post<any>(`${environment.apiUrl}/auth/refresh-token`, {
      'token': this.getRefreshToken()
      })
      .pipe(map(user => {
        this.storeTokens(user.jwtToken, user.refreshToken);
        this.userService.setupUser(user.username, user.userRole);
      }))
      .pipe(catchError(err => this.checkError(err)));
  }

  getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  getUserInfo() {
    return this.http.get<UserInformation>(`${environment.apiUrl}/auth/user-profile`);
  }

  updateUserInformation(userInformation: UserInformation) : Observable<UserInformation>{
    return this.http.put<UserInformation>(`${environment.apiUrl}/auth/user-profile/${userInformation.id}`,userInformation);

  }

  updateUserPassword(changePassword: ChangePassword) {
    return this.http.post(`${environment.apiUrl}/auth/password`,changePassword);
  }

  registerClient(registrationFrom: RegistrationForm) {
    return this.http.post<any>(`${environment.apiUrl}/auth/register/client`, registrationFrom);
  }

  doLoginUser(user: User) {
    this.storeTokens(user.jwtToken, user.refreshToken);
  }

  private doLogoutUser() {
    this.removeTokens();
  }

  private checkError(error: any): any {
    this.doLogoutUser();
    this.userService.removeUser();
  }

  private storeTokens(jwtToken: string, refreshToken: string) {
    localStorage.setItem(this.JWT_TOKEN, jwtToken);
    localStorage.setItem(this.REFRESH_TOKEN, refreshToken);
  }

  private storeJwtToken(user: User) {
    localStorage.setItem(this.JWT_TOKEN, user.jwtToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }

  getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

}
