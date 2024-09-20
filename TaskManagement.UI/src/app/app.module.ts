import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CompanyCreateComponent } from './components/company-create/company-create.component';
import { CompanyEditComponent } from './components/company-edit/company-edit.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectComponent } from './components/project/project.component';
import { TaskComponent } from './components/task/task.component';
import { UserComponent } from './components/user/user.component'; // <-- Import HttpClientModule

@NgModule({
  declarations: [
    AppComponent,
    CompanyListComponent,
    CompanyDetailsComponent,
    CompanyCreateComponent,
    CompanyEditComponent,
    ProjectComponent,
    TaskComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule  // <-- Add HttpClientModule to imports
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
