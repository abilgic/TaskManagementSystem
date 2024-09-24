import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

interface Company {
  id: number; // Make 'id' required
  name: string;
  userLimit: number;
  projectLimit: number;
  activeUntil: string; // Use string for compatibility
}

@Component({
  selector: 'app-company-management',
  templateUrl: './company-management.component.html',
  styleUrls: ['./company-management.component.css']
})
export class CompanyManagementComponent implements OnInit {
  companies: Company[] = [];
  companyForm: Company = { id: 0, name: '', userLimit: 0, projectLimit: 0, activeUntil: '' }; // Initialize id
  isEdit = false;
  editingCompanyId?: number;

  constructor() { }

  ngOnInit(): void {
    // Initialization logic, e.g., fetching companies from a service
  }

  onSubmit(): void {
    if (this.isEdit) {
      this.updateCompany();
    } else {
      this.addCompany();
    }
    this.resetForm();
  }

  addCompany(): void {
    const newCompany: Company = { ...this.companyForm, id: Date.now() }; // Sample ID generation
    this.companies.push(newCompany);
  }

  editCompany(company: Company): void {
    this.isEdit = true;
    this.editingCompanyId = company.id;
    this.companyForm = { ...company };
  }

  updateCompany(): void {
    if (this.editingCompanyId === undefined) {
      // Handle the case where editingCompanyId is undefined (optional)
      return; // or throw an error, or whatever makes sense for your application
    }

    const index = this.companies.findIndex(company => company.id === this.editingCompanyId);
    if (index !== -1) {
      this.companies[index] = { ...this.companyForm, id: this.editingCompanyId }; // Keep the same ID
    }
    this.isEdit = false;
    this.editingCompanyId = undefined;
  }


  deleteCompany(id: number): void {
    this.companies = this.companies.filter(company => company.id !== id);
  }

  resetForm(): void {
    this.companyForm = { id: 0, name: '', userLimit: 0, projectLimit: 0, activeUntil: '' }; // Reset form
    this.isEdit = false;
    this.editingCompanyId = undefined;
  }
}
