import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/Auth/auth.service';
import { ComicsService } from '../../Services/comics.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: [DatePipe]
})
export class DashboardComponent implements OnInit{

  user: any;
  comics: any[] = [];
  isLoading = true;

  constructor(
    private authService: AuthService, 
    private comicsService: ComicsService,
    private datePipe: DatePipe
  ) {}

  ngOnInit() {
    this.user = this.authService.getUserInfo();
    this.loadComics();
  }

  loadComics() {
    this.comicsService.getComics().subscribe({
      next: (data) => {
        this.comics = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
        console.error('Error al obtener cómics:', err);
      }
    });
  }

  addToFavorites(comic: any) {

    this.authService.loadUserData().subscribe({
      next: (user) => {
        this.user = user;
        this.saveFavorite(comic);
      },
      error: (err) => {
        console.error('Error al cargar los datos del usuario', err);
      }
    });
  }

  saveFavorite(comic: any){
    this.comicsService.addToFavorites(comic.id, this.user.id).subscribe({
      next: (data) => {
        if (data.result == 0) {
          alert(data.message)
        }
        else{
          alert(data.message)
        }
      },
      error: (err) => {
        console.error('Error al agregar a favoritos:', err);
      }
    });
  }

  formatModifiedDate(date: string | null): string {
    if (date) {
      return this.datePipe.transform(date, 'dd/MM/yyyy') || '';
    }
    return '';
  }
  

  logout() {
    this.authService.logout();
    window.location.reload();
  }

}
