import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/Auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm: FormGroup;
  showPassword: boolean = false;
  errorMessage: string = '';
  isLoading = true;

  constructor(private fb: FormBuilder, private router: Router,private authService: AuthService,) {
    // eliminar cualquier token
    localStorage.removeItem('token');
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  onLogin() {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;

      this.authService.login(email, password).subscribe({
        next: (response) => {
          if (response.result == null) {
            this.errorMessage = 'Credenciales incorrectas';
            this.isLoading = false
          }
          else{
            localStorage.setItem('token', response.result.token); // Guardar token si la API lo devuelve
            this.errorMessage = ""
            this.isLoading = false
            this.router.navigate(['/dashboard']);
          }
          
        },
        error: () => {
          this.errorMessage = 'Ha ocurrido un error';
        },
      });
    }
  }

  // Método para obtener controles del formulario en la plantilla
  get formControls() {
    return this.loginForm.controls;
  }

}
