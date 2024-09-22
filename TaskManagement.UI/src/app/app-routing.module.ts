import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CompanyManagementComponent } from './company-management/company-management.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },

  {
    path: 'dashboard', component: DashboardComponent, children: [
      { path: 'company-management', component: CompanyManagementComponent, canActivate: [AuthGuard] }
    ]
  },

  { path: '**', redirectTo: '/login' } // This should be last
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
