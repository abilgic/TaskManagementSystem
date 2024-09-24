// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CompanyManagementComponent } from './company-management/company-management.component';
import { LoginComponent } from './login/login.component'; // assuming you have a login route
import { AuthGuard } from './auth/auth.guard'; // assuming you have auth guard

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard], // Guard the dashboard with auth guard if applicable
    children: [
      { path: 'companies', component: CompanyManagementComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
