import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from "@auth0/angular-jwt";
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  helper = new JwtHelperService();
  constructor(private myRoutes: Router) {}

  canActivate(): boolean {
    if(!this.helper.isTokenExpired(localStorage.getItem('myToken'))) { return true; }
    this.myRoutes.navigate(['/home']);
  }
}
