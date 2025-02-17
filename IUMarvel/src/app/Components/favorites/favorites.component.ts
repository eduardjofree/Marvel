import { Component, Input } from '@angular/core';
import { ComicsService } from '../../Services/comics.service';
import { AuthService } from '../../Services/Auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.css'
})
export class FavoritesComponent {

  user: any;
  favorites: any[] = [];
  isLoading = true;

  constructor(private comicsService: ComicsService, private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.authService.loadUserData().subscribe({
      next: (user) => {
        this.user = user;
        this.loadFavorites();
      },
      error: (err) => {
        console.error('Error al cargar los datos del usuario', err);
      }
    });
  }

  loadFavorites() {
    this.comicsService.getFavorites(this.user.id).subscribe({
      next: (data) => {
        this.isLoading = false;
        this.favorites = data;
      },
      error: (err) => {
        this.isLoading = false;
        console.error('Error al obtener favoritos:', err);
      }
    });
  }

  goToDashboard(): void {
    this.router.navigate(['/dashboard']);
  }

  removeFromFavorites(comicId: number): void {
    this.comicsService.removeFavorite(this.user.id, comicId).subscribe({
      next: (data) => {
        
        if (data.result == 1) {
          this.favorites = this.favorites.filter(comic => comic.id !== comicId);
          alert(data.message)
        }
        else{
          alert(data.message)
        }
        
      },
      error: (err) => console.error('Error al eliminar de favoritos', err)
    });
  }

}
