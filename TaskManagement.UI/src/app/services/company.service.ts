// src/app/services/company.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = 'http://localhost:1162/api/companies'; // Adjust to your API URL

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  createCompany(companyData: any): Observable<any> {
    return this.http.post(this.apiUrl, companyData);
  }

  updateCompany(id: number, companyData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, companyData);
  }

  deleteCompany(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
