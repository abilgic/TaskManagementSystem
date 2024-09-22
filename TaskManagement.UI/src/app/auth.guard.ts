import { Injectable } from '@angular/core';

import { AuthService } from './services/auth.service'; // Adjust the path to your AuthService
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  //canActivate(route: ActivatedRouteSnapshot,
  //  state: RouterStateSnapshot): boolean {
  //  const isLoggedIn = this.authService.isLoggedIn();
  //  console.log('AuthGuard: checking login status:', isLoggedIn);

  //  if (isLoggedIn) {
  //    return true;
  //  } else {
  //    console.log('AuthGuard: user not logged in, redirecting to login');
  //    this.router.navigate(['/login']);
  //    return false;
  //  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    
    const isLoggedIn = this.authService.isLoggedIn();
    console.log('AuthGuard active:', isLoggedIn);

    if (isLoggedIn) {
      return true;
    } else {
      console.log('Redirecting to login');
      this.router.navigate(['/login']);
      return false;
    }
  }
  }

