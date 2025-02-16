import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm: FormGroup;
  showPassword: boolean = false;
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private router: Router) {
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

      // Simulación de autenticación (cambiar por una API real)
      if (email === 'admin@email.com' && password === '123456') {
        this.router.navigate(['/dashboard']); // Redirige al dashboard
      } else {
        this.errorMessage = 'Correo o contraseña incorrectos';
      }
    }
  }

  // Método para obtener controles del formulario en la plantilla
  get formControls() {
    return this.loginForm.controls;
  }

}
