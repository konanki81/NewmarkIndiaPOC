import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BobinfoComponent } from '../blob/bobinfo/bobinfo.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,BobinfoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'NewmarkIndia.AngularUI';
}
