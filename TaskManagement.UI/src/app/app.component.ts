// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { Company } from './models/company.model';  // Import the Company model
import { CompanyService } from './services/company.service';  // Import your service

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TaskManagementSystem';

  companies: Company[] = [];  // Define the companies property

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    // Fetch companies from the service on initialization
    this.companyService.getCompanies().subscribe((data: Company[]) => {
      this.companies = data;
    });
  }
}
