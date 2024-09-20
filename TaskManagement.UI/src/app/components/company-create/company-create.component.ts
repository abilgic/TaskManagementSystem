import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CompanyService } from '../../services/company.service';

@Component({
  selector: 'app-company-create',
  templateUrl: './company-create.component.html',
  styleUrls: ['./company-create.component.css']
})
export class CompanyCreateComponent {
  company: any = {};

  constructor(
    private companyService: CompanyService,
    private router: Router
  ) { }

  createCompany(): void {
    this.companyService.createCompany(this.company).subscribe(() => {
      this.router.navigate(['/companies']);
    });
  }
}
