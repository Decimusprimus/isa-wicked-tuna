import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map, mapTo, tap } from 'rxjs/operators';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';
import { RegistrationForm } from '../_models/registrationForm';
import { UserInformation } from '../_models/userInformation';
import { ChangePassword } from '../_models/changePassword';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  public loggedUser: User | null;

  private userSubject: BehaviorSubject<any>;
  public user: Observable<User>;

  constructor(private http: HttpClient) {
    this.loggedUser = new User();
    this.userSubject = new BehaviorSubject<any>(null);
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
}


  login(username: string, password: string): Observable<boolean> {
    return this.http.post<any>(`${environment.apiUrl}/auth/login`, {username, password})
    .pipe(
      tap(user => this.doLoginUser(user)),
      mapTo(true),
      catchError(error => {
        alert(error.error);
        return of(false);
      })
    );
  }

  // login(username: string, password: string) {
  //     return this.http.post<any>(`${environment.apiUrl}/users/authenticate`, { username, password }, { withCredentials: true })
  //         .pipe(map(user => {
  //             this.userSubject.next(user);
  //             this.startRefreshTokenTimer();
  //             return user;
  //         }));
  // }



  logout() {
    return this.http.post<any>(`${environment.apiUrl}/auth/revoke-token`, {
      'token': this.getRefreshToken()
    }).pipe(
      tap(() => this.doLogoutUser()),
      mapTo(true),
      catchError(error => {
        alert(error.error);
        return of(false);
      }));
  }


  //registerClient(email: string, password: string, passwordRepeated: string, name: string, surname: string) {
  registerClient(registrationFrom: RegistrationForm) {
    return this.http.post<any>(`${environment.apiUrl}/auth/register/client`, registrationFrom);
  }

  // logout() {
  //     this.http.post<any>(`${environment.apiUrl}/users/revoke-token`, {}, { withCredentials: true }).subscribe();
  //     this.stopRefreshTokenTimer();
  //     this.userSubject.next(null);
  //     this.router.navigate(['/login']);
  // }

  isLoggedIn() {
    return !!this.getJwtToken();
  }

  refreshToken() {
      return this.http.post<any>(`${environment.apiUrl}/auth/refresh-token`, {
        'token': this.getRefreshToken()
      }, { withCredentials: true })
          .pipe(tap(user => {
            this.storeJwtToken(user);
          }));
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

  doLoginUser(user: User) {
    console.log(user);
      this.loggedUser = user;
      this.storeTokens(user.jwtToken, user.refreshToken);
      this.userSubject.next(user);
  }

  private doLogoutUser() {
    this.loggedUser = null;
    this.removeTokens();
    this.userSubject.next(null);
  }

  private storeTokens(jwtToken: string, refreshToken: string) {
    localStorage.setItem(this.JWT_TOKEN, jwtToken);
    localStorage.setItem(this.REFRESH_TOKEN, refreshToken);
  }

  private storeJwtToken(user: User) {
    this.userSubject.next(user);
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
