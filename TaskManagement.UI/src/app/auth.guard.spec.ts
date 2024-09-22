import { TestBed } from '@angular/core/testing';
import { AuthGuard } from './auth.guard';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

describe('AuthGuard', () => {
  let authService: AuthService;
  let router: Router;

  beforeEach(() => {
    const authServiceMock = {
      isLoggedIn: jasmine.createSpy('isLoggedIn').and.returnValue(true) // Change to false for negative tests
    };

    const routerMock = {
      navigate: jasmine.createSpy('navigate')
    };

    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: AuthService, useValue: authServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    });

    authService = TestBed.inject(AuthService);
    router = TestBed.inject(Router);
  });

  it('should be created', () => {
    const guard: AuthGuard = TestBed.inject(AuthGuard);
    expect(guard).toBeTruthy();
  });

  it('should allow access if user is logged in', () => {
    const guard: AuthGuard = TestBed.inject(AuthGuard);
    const route: ActivatedRouteSnapshot = {} as ActivatedRouteSnapshot; // Mocked route
    const state: RouterStateSnapshot = {} as RouterStateSnapshot; // Mocked state
    const result = guard.canActivate(route, state);
    expect(result).toBeTrue();
  });

  it('should redirect to login if user is not logged in', () => {
    const authServiceMock = {
      isLoggedIn: jasmine.createSpy('isLoggedIn').and.returnValue(false) // Simulate not logged in
    };
    TestBed.overrideProvider(AuthService, { useValue: authServiceMock });

    const guard: AuthGuard = TestBed.inject(AuthGuard);
    const route: ActivatedRouteSnapshot = {} as ActivatedRouteSnapshot; // Mocked route
    const state: RouterStateSnapshot = {} as RouterStateSnapshot; // Mocked state
    guard.canActivate(route, state);
    expect(router.navigate).toHaveBeenCalledWith(['/login']);
  });
});
