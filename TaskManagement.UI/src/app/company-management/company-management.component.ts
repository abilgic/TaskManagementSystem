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

  // Ensure the companyForm matches the Company interface
  companyForm: Company = {
    id: 0, // Add id for clarity in the form
    name: '',
    userLimit: 0, // Ensure these are the correct types
    projectLimit: 0,
    activeUntil: new Date() // Default value as Date
  };

  isEdit = false;
  editingCompanyId: number | null = null;

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.loadCompanies();
  }

  loadCompanies() {
    this.companyService.getCompanies().subscribe(data => {
      this.companies = data;
    });
  }

  onSubmit() {
    if (this.isEdit) {
      this.companyService.updateCompany(this.editingCompanyId!, this.companyForm).subscribe(() => {
        this.loadCompanies();
        this.resetForm();
      });
    } else {
      this.companyService.createCompany(this.companyForm).subscribe(() => {
        this.loadCompanies();
        this.resetForm();
      });
    }
  }

  editCompany(company: Company) {
    this.isEdit = true;
    this.editingCompanyId = company.id;
    this.companyForm = { ...company };
  }

  deleteCompany(id: number) {
    this.companyService.deleteCompany(id).subscribe(() => {
      this.loadCompanies();
    });
  }

  resetForm() {
    this.isEdit = false;
    this.editingCompanyId = null;
    this.companyForm = {
      id: 0,
      name: '',
      userLimit: 0,
      projectLimit: 0,
      activeUntil: new Date() // Reset to today's date
    };
  }
}
