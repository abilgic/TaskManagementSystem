import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { AuthGuard } from './auth.guard'; // Update the import to AuthGuard
import { RouterTestingModule } from '@angular/router/testing';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let router: Router;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule], // Import RouterTestingModule for routing tests
      providers: [AuthGuard]
    });

    guard = TestBed.inject(AuthGuard); // Inject AuthGuard
    router = TestBed.inject(Router); // Inject Router if you need to test routing behavior
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should allow activation if token exists', () => {
    localStorage.setItem('token', 'test-token'); // Simulate a token being set
    expect(guard.canActivate()).toBeTrue();
  });

  it('should not allow activation and redirect if token does not exist', () => {
    spyOn(router, 'navigate'); // Spy on the navigate method
    localStorage.removeItem('token'); // Ensure no token is set
    expect(guard.canActivate()).toBeFalse();
    expect(router.navigate).toHaveBeenCalledWith(['/login']); // Check if navigate was called with '/login'
  });
});
