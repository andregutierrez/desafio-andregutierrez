import { Component } from '@angular/core';
import { environment } from './environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Andre Gutierrez';
  api = environment.API_URL;
}
