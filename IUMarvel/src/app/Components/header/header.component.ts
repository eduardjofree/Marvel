import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/Auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  user: any = {};
  isAuthenticated: boolean = false;

  constructor(public authService: AuthService, private router: Router) {}

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
    this.authService.isAuthenticated = false
    localStorage.removeItem('token');
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}
