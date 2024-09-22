import { Component } from '@angular/core';
import { Router } from '@angular/router';  // For navigation after logout
import { AuthService } from '../../services/auth.service';  // Import your authentication service

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.css']
})
export class DashboardLayoutComponent {

  constructor(private authService: AuthService, private router: Router) { }

  logout() {
    // Call the logout method in your AuthService
    this.authService.logout();

    // Redirect to the login page after logout
    this.router.navigate(['/login']);
  }
}
