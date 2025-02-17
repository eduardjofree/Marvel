import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComicsService {

  private apiUrl = 'http://localhost:5132/api';
  token: string | null = localStorage.getItem('token');

  constructor(private http: HttpClient) {}

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }

  getComics(): Observable<any[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
    return this.http.get<any[]>(`${this.apiUrl}/Comics/GetAllComics`, {headers});
  }

  addToFavorites(comicId: number, userId: number): Observable<any> {
    const body = { userId, comicId };
    return this.http.post<any>(`${this.apiUrl}/favorites/AddFavorites`, body, { headers: this.getAuthHeaders() });
  }

  getFavorites(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/favorites/GetFavoritesByUserId?userId=${userId}`, { headers: this.getAuthHeaders() });
  }

  getComicDetails(comicId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Comics/GetComicById/${comicId}`, { headers: this.getAuthHeaders() });
  }

  removeFavorite(userId: number, comicId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/favorites/DeleteFavoriteComic?userId=${userId}&comicId=${comicId}`, { headers: this.getAuthHeaders() });
  }
}
