import { Component } from '@angular/core';
import { AuthService } from './Services/Auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'IUMarvel';
  constructor(public authService: AuthService){}
}
