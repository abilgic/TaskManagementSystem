import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from '../../services/company.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  company: any = {};

  constructor(
    private companyService: CompanyService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.companyService.getCompany(id).subscribe(data => {
      this.company = data;
    });
  }

  updateCompany(): void {
    const id = this.route.snapshot.params['id'];
    this.companyService.updateCompany(id, this.company).subscribe(() => {
      this.router.navigate(['/companies']);
    });
  }
}
