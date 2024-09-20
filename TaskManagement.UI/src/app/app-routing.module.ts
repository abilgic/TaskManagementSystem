import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CompanyCreateComponent } from './components/company-create/company-create.component';
import { CompanyEditComponent } from './components/company-edit/company-edit.component';
import { ProjectComponent } from './components/project/project.component';
import { TaskComponent } from './components/task/task.component';
import { UserComponent } from './components/user/user.component';
const routes: Routes = [
  { path: 'users', component: UserComponent },
  { path: 'tasks', component: TaskComponent },
  { path: 'projects', component: ProjectComponent },
  { path: 'companies', component: CompanyListComponent },
  { path: 'companies/create', component: CompanyCreateComponent },
  { path: 'companies/:id', component: CompanyDetailsComponent },
  { path: 'companies/:id/edit', component: CompanyEditComponent },
  { path: '', redirectTo: '/companies', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
