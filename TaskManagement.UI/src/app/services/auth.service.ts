// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from '../models/user.model';

interface LoginRequest {
  username: string;
  password: string;
}

interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:1162/api/login/authenticate'; // Update to your API URL
  private roles: string[] = [];

  constructor(private http: HttpClient, private router: Router) { }

  //login(loginRequest: { username: string; password: string }): Observable<LoginResponse> {
  //  return this.http.post<LoginResponse>(this.apiUrl, loginRequest).pipe(
  //    tap((response: LoginResponse) => { // Specify the type here
  //      console.log('Login successful:', response); // Log success
  //      localStorage.setItem('authToken', response.token); // Store the token
  //      this.setRolesFromToken(response.token); // Extract roles from token

  //      // Store user info
  //      const user = { username: loginRequest.username, roles: this.roles };
  //      localStorage.setItem('currentUser', JSON.stringify(user));
  //    }),
  //    catchError(error => {
  //      console.error('Login failed:', error);
  //      return throwError('Invalid username or password'); // Rethrow the error
  //    })
  //  );
  //}
  login(loginRequest: { username: string; password: string }): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.apiUrl, loginRequest).pipe(
      tap((response: LoginResponse) => {
        localStorage.setItem('authToken', response.token);
         
      }),
      catchError(error => {
        console.error('Login failed:', error);
        return throwError('Invalid username or password');
      })
    );
  }
  logout() {
    console.log('Logging out...');
    localStorage.removeItem('authToken'); // Clear the token from localStorage
    this.router.navigate(['/login']); // Navigate to login
  }
  // Define the setRolesFromToken method
  private setRolesFromToken(token: string): void {
    const decodedToken = this.decodeToken(token);
    if (decodedToken && decodedToken.roles) {
      this.roles = decodedToken.roles; // Assuming the token payload contains a 'roles' field
    }
  }

  // Simple utility to decode JWT token
  public decodeToken(token: string): any {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (error) {
      console.error('Failed to decode token:', error);
      return null;
    }
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('authToken'); // Adjust according to your implementation
    console.log('AuthService: checking token:', token); // Log token state
    console.log('Checking login status, token found:', !!token); 
    return !!token; // Returns true if a token exists
  }

}
