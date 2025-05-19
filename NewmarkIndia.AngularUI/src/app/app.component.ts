import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BobinfoComponent } from './bobinfo/bobinfo.component';

import { AllCommunityModule, ModuleRegistry } from 'ag-grid-community';
import { MasterDetailModule } from 'ag-grid-enterprise'; 

ModuleRegistry.registerModules([AllCommunityModule,MasterDetailModule]);





@Component({
  selector: 'app-root',
  imports: [RouterOutlet,BobinfoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'NewmarkIndia.AngularUI';
}
