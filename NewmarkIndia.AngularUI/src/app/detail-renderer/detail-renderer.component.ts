import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { AgGridModule } from 'ag-grid-angular';

@Component({
  selector: 'app-detail-renderer',
  standalone: true,
  templateUrl: './detail-renderer.component.html',
  styleUrls: ['./detail-renderer.component.css'],
  imports: [CommonModule, AgGridModule, MatTabsModule]
})
export class DetailRendererComponent {
  transportation: any[] = [];
  spaces: any[] = [];


  
  // Called by ag-Grid
  agInit(params: any): void {
     console.log('detail render page');
    this.transportation = params?.data?.transportation ?? [];
    this.spaces = params?.data?.spaces ?? [];
  }
   
}