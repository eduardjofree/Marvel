import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../Services/Auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  registerForm: FormGroup;
  errorMessage: string = '';
  isRegistered: boolean = false;
  showPassword: boolean = false;
  showConfirmPassword: boolean = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      nombre: ['', Validators.required],
      identificacion: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, { validator: this.passwordsMatchValidator });
  }

  // Validación personalizada para que las contraseñas coincidan
  passwordsMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;
    if (password !== confirmPassword) {
      return { passwordsMismatch: true }; // Devuelve un objeto con error
    }
    return null; // Devuelve null si no hay errores
  }

  // Método para registrar usuario
  register() {
    if (this.registerForm.invalid) {
      this.errorMessage = 'Por favor, complete correctamente el formulario.';
      return;
    }

    const formData = this.registerForm.value;

    this.authService.register(this.registerForm.value).subscribe({
      next: (response) => {
        if (response.result == 0) {
          this.errorMessage = ""
          alert(response.message);
        }
        else{
          // this.isRegistered = true;
          this.errorMessage = ""
          alert(response.message);
          this.resetForm();
        }
        
      },
      error: () => {
        this.errorMessage = 'Ha ocurrido un error al guardar el usuario';
      },
    });

  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  toggleConfirmPasswordVisibility() {
    this.showConfirmPassword = !this.showConfirmPassword;
  }

  // Redirigir a la página de inicio de sesión o cualquier otra página
  redirectToLogin() {
    this.router.navigate(['/login']);
  }

  resetForm() {
    this.registerForm.reset();
    this.showPassword = false;
    this.showConfirmPassword = false;
  }

}
