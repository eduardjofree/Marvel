import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/Auth/auth.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'] // 🔹 Estaba mal escrito "styleUrl" → debe ser "styleUrls"
})
export class HeaderComponent implements OnInit {

  user: any = {};
  isAuthenticated: boolean = false;
  currentRoute: string = '';

  constructor(public authService: AuthService, private router: Router) {
    // Detecta cambios en la URL para mostrar los botones correctos
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.currentRoute = event.urlAfterRedirects; // ✅ Captura la ruta final después de redirecciones
      }
    });
  }

  ngOnInit(): void {
    this.authService.loadUserData().subscribe({
      next: (data) => {
        this.user = data;
        this.isAuthenticated = this.authService.isLoggedIn();
      },
      error: (err) => {
        console.error('Error al cargar los datos del usuario', err);
      }
    });
  }

  logout(): void {
    this.isAuthenticated = false;
    this.authService.isAuthenticated = false;
    localStorage.removeItem('token');
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
