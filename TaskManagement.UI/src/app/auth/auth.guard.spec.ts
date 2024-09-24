import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { of } from 'rxjs';

describe('AuthGuard', () => {
  let authServiceMock: jasmine.SpyObj<AuthService>;
  let routerMock: jasmine.SpyObj<Router>;

  // Create a function to execute the guard with necessary parameters
  const executeGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) =>
    TestBed.runInInjectionContext(() => new AuthGuard(authServiceMock, routerMock).canActivate(route, state));

  beforeEach(() => {
    // Create mocks for AuthService and Router
    authServiceMock = jasmine.createSpyObj('AuthService', ['isLoggedIn']);
    routerMock = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      providers: [
        { provide: AuthService, useValue: authServiceMock },
        { provide: Router, useValue: routerMock },
      ],
    });
  });

  it('should allow access if authenticated', () => {
    // Simulate an authenticated user
    authServiceMock.isLoggedIn.and.returnValue(true);
    const route = {} as ActivatedRouteSnapshot;  // Mock ActivatedRouteSnapshot
    const state = {} as RouterStateSnapshot;      // Mock RouterStateSnapshot
    const result = executeGuard(route, state);
    expect(result).toBeTruthy();
  });

  it('should deny access and navigate to login if not authenticated', () => {
    // Simulate an unauthenticated user
    authServiceMock.isLoggedIn.and.returnValue(false);
    const route = {} as ActivatedRouteSnapshot;  // Mock ActivatedRouteSnapshot
    const state = {} as RouterStateSnapshot;      // Mock RouterStateSnapshot
    const result = executeGuard(route, state);
    expect(result).toBeFalsy();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });
});
