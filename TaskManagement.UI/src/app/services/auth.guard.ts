import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  canActivate(): boolean {
    const token = localStorage.getItem('token');

    // If a token is found and is valid, allow route activation
    if (token && this.authService.isTokenValid(token)) {
      return true;
    } else {
      // Logout the user and navigate to login page if token is not found/invalid
      this.authService.logout(); // Clear the token if it's invalid or missing
      this.router.navigate(['/login']);
      return false;
    }
  }
}
