import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:1162/api/login/authenticate'; // Replace with your backend URL

  constructor(private http: HttpClient, private router: Router) { }

  login(loginRequest: { username: string, password: string }): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.apiUrl, loginRequest);
  }
  logout() {
    // Clear token or any authentication info from storage
    localStorage.removeItem('authToken');  // Assuming you're using localStorage
    sessionStorage.clear();  // Clear sessionStorage if needed
  }
  isTokenValid(token: string): boolean {
    // For now, just check if the token exists
    // You can expand this to validate the token's format or expiration
    return !!token; // returns true if token is not null or undefined
  }

}
