import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map, mapTo, tap } from 'rxjs/operators';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';


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
      return this.http.post<any>(`${environment.apiUrl}/auth/refresh-token`, {}, { withCredentials: true })
          .pipe(tap(user => {
            this.storeJwtToken(user);
          }));
  }

  getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  private doLoginUser(user: User) {
    console.log(user);
      this.loggedUser = user;
      this.storeTokens(user.jwtToken, user.refreshToken);
      this.userSubject.next(user);
  }

  private doLogoutUser() {
    this.loggedUser = null;
    this.userSubject.next(null);
    this.removeTokens();
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

  private getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

}
