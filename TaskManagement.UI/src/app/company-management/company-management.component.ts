import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company.model';

@Component({
  selector: 'app-company-management',
  templateUrl: './company-management.component.html',
  styleUrls: ['./company-management.component.css']
})
export class CompanyManagementComponent implements OnInit {
  companies: Company[] = [];
  newCompany: Company = {
    name: '',
    userLimit: 0,
    projectLimit: 0,
    activeUntil: new Date()
  };

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.loadCompanies();
  }

  loadCompanies(): void {
    this.companyService.getAllCompanies().subscribe((data: Company[]) => {
      this.companies = data;
    });
  }

  addCompany(): void {
    this.companyService.addCompany(this.newCompany).subscribe(() => {
      this.loadCompanies(); // Reload company list after adding
      this.resetForm();
    });
  }

  deleteCompany(companyId: number): void {
    if (confirm('Are you sure you want to delete this company?')) {
      this.companyService.deleteCompany(companyId).subscribe(() => {
        this.loadCompanies(); // Reload company list after deletion
      });
    }
  }

  resetForm(): void {
    this.newCompany = {
      name: '',
      userLimit: 0,
      projectLimit: 0,
      activeUntil: new Date()
    };
  }
}
