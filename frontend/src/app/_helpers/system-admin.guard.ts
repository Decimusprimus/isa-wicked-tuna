import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../_core';

@Injectable({
  providedIn: 'root'
})
export class SystemAdminGuard implements CanActivate {
  constructor(
    private userService: UserService,
    private router: Router,
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if(this.userService.isUserPresent() && this.userService.currentUser.userRole === 'SystemAdmin') {
        return true;
      } else {
        this.router.navigate(['forbidden']);
        return false;
      }
  }
  
}
