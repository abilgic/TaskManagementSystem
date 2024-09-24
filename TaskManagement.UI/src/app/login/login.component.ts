import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  errorMessage: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value; // Destructure username and password

      // Assuming the login method takes two parameters
      this.authService.login(username, password).subscribe({
        next: (response) => {
          console.log('Login successful');
          this.router.navigate(['/dashboard']); // Redirect to dashboard on successful login
        },
        error: (error) => {
          console.error('Login failed', error);
          this.errorMessage = 'Login failed. Please check your username and password.'; // Set error message on failure
        }
      });
    }
  }
}
