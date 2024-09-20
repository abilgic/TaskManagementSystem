
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { CompanyService } from '../../../../taskmanagement.ui/src/app/services/company.service'; // Add CompanyService
import { of } from 'rxjs'; // Use 'of' to mock observables
import { Company } from '../../../../taskmanagement.ui/src/app/models/company.model'; // Add Company model
import { HttpClientTestingModule } from '@angular/common/http/testing'; // Add HttpClientTestingModule

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let app: AppComponent;
  let companyService: jasmine.SpyObj<CompanyService>;

  beforeEach(async () => {
    const companyServiceSpy = jasmine.createSpyObj('CompanyService', ['getCompanies']); // Spy on CompanyService

    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      providers: [
        { provide: CompanyService, useValue: companyServiceSpy } // Provide mock CompanyService
      ],
      imports: [HttpClientTestingModule] // Import HttpClientTestingModule for HTTP calls
    }).compileComponents();

    // Inject the service and mock data
    companyService = TestBed.inject(CompanyService) as jasmine.SpyObj<CompanyService>;
    companyService.getCompanies.and.returnValue(of([
      { id: 1, name: 'Test Company', projectLimit: 10, userLimit: 50, activeUntil: new Date(), projects: [], users: [] }
    ]));

    // Create component and access its instance
    fixture = TestBed.createComponent(AppComponent);
    app = fixture.componentInstance;
  });

  it('should create the app', () => {
    expect(app).toBeTruthy();
  });

  it('should have companies', () => {
    fixture.detectChanges(); // Trigger ngOnInit
   
  });
});
