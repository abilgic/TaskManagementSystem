import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private baseUrl = 'http://localhost:1162/api/companies'; // Update with your actual API URL

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }

  getCompany(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  createCompany(company: any): Observable<any> {
    return this.http.post(`${this.baseUrl}`, company);
  }

  updateCompany(id: number, company: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, company);
  }

  deleteCompany(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
