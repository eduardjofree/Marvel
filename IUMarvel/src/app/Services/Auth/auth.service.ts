import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private apiUrl = 'http://localhost:5132/api';
  isAuthenticated = false;
  user: any = {};
  token: string | null = localStorage.getItem('token');

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    const body = { email, password };
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  
    return this.http.post<any>(`${this.apiUrl}/auth/login`, body, httpOptions).pipe(
      tap(response => {
        if (response.result?.token != null) {
          this.isAuthenticated = true;
          localStorage.setItem('token', response.result.token);
          this.token = response.result.token;
        }
      })
    );
  }

  register(userData: any): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`,
      'Content-Type': 'application/json'
    });
    return this.http.post(`${this.apiUrl}/user/register`, userData, { headers });
  }

  getUserInfo(): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    return this.http.get<any>(`${this.apiUrl}/user/profile`, { headers });
  }

  logout() {
    localStorage.removeItem('user');
    this.token = null;
  }
  
  // Verificar si está autenticado
  isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      this.isAuthenticated = true
      this.token = token;
    }
    return this.isAuthenticated;
  }

  isAuthenticatedUser(): boolean {
    return !!localStorage.getItem('token');
  }

  loadUserData(): Observable<any> {
    return this.getUserInfo();
  }
}
