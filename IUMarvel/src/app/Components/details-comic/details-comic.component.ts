import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComicsService } from '../../Services/comics.service';

@Component({
  selector: 'app-details-comic',
  templateUrl: './details-comic.component.html',
  styleUrl: './details-comic.component.css'
})
export class DetailsComicComponent implements OnInit {

  comic: any;

  constructor(
    private route: ActivatedRoute,
    private comicsService: ComicsService
  ) {}

  ngOnInit() {
    // Obtener el id del cómic desde la ruta
    const comicId = this.route.snapshot.paramMap.get('id');
    if (comicId) {
      this.loadComicDetails(comicId);
    }
  }

  loadComicDetails(comicId: string) {
    this.comicsService.getComicDetails(comicId).subscribe({
      next: (data) => {
        this.comic = data;
      },
      error: (err) => {
        console.error('Error al obtener los detalles del cómic:', err);
      }
    });
  }

}
