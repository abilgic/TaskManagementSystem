
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CompanyCreateComponent } from './components/company-create/company-create.component';
import { CompanyEditComponent } from './components/company-edit/company-edit.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectComponent } from './components/project/project.component';
import { TaskComponent } from './components/task/task.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './login/login.component'; // <-- Import HttpClientModule
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth-interceptor.service';
import { DashboardComponent } from './dashboard/dashboard.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatCardModule } from '@angular/material/card'; // Ensure this import is present
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardLayoutComponent } from './layout/dashboard-layout/dashboard-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    CompanyListComponent,
    CompanyDetailsComponent,
    CompanyCreateComponent,
    CompanyEditComponent,
    ProjectComponent,
    TaskComponent,
    UserComponent,
    LoginComponent,
    DashboardComponent,
    DashboardLayoutComponent
  ],
  imports: [
    MatCardModule,
    FlexLayoutModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule  // <-- Add HttpClientModule to imports
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }, provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }
