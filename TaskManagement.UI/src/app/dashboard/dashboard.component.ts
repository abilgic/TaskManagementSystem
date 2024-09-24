import { Component } from '@angular/core';
import { Router } from '@angular/router'; // Import router for redirection

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  constructor(private router: Router) { }

  onLogout() {
    // Clear authentication token from local storage
    localStorage.removeItem('authToken');

    // Navigate back to the login page
    this.router.navigate(['/login']);
  }
}
