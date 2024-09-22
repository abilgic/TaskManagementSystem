import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { UserService } from '../services/user.service';
import { Company } from '../models/company.model';
import { User } from '../models/user.model';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  companies: Company[] = [];
  currentAdminUserId: number | null | undefined = undefined; // Allow undefined


  users: User[] = [];

  constructor(private authService: AuthService, private router: Router,
    private companyService: CompanyService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.loadCompanies();
    this.loadUsers();
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);  // Redirect to login page after logout
  }
  loadCompanies(): void {
    this.companyService.getCompanies().subscribe(data => {
      this.companies = data;
      // Set currentAdminUserId from the first company
      if (this.companies.length > 0) {
        this.currentAdminUserId = this.companies[0].adminUserId !== undefined ? this.companies[0].adminUserId : null; // Fallback to null
      }
    });
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
      // Optionally set currentAdminUserId based on user data if relevant
    });
  }

  createCompany(newCompany: Company): void {
    // Ensure that the admin user is linked properly
    newCompany.adminUserId = this.currentAdminUserId; // Current admin user ID
    this.companyService.createCompany(newCompany).subscribe(() => {
      this.loadCompanies(); // Refresh company list
    });
  }
}
