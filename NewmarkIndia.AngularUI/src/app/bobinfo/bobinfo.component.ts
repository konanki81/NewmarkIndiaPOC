import { Component, OnInit } from '@angular/core';
import { BlobdataService } from '../../services/blobdata.service';
import { Blobinfo } from '../../classes/blobinfo';
import { AgGridAngular } from 'ag-grid-angular';
 import { ColDef, GridApi, GridOptions, ValueGetterParams } from 'ag-grid-community';

import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';
import { DetailRendererComponent } from '../detail-renderer/detail-renderer.component';


@Component({
  selector: 'app-bobinfo',
  templateUrl: './bobinfo.component.html',
  styleUrls: ['./bobinfo.component.css'],
  standalone: true,
  imports: [CommonModule, AgGridModule],

})
export class BobinfoComponent implements OnInit {

 public detailCellRenderer = DetailRendererComponent;

 detailCellRendererParams = {
    detailCellRenderer: DetailRendererComponent,
    getDetailRowData: (params: any) => {
      params.successCallback(params.data);  // Provide full row data
    }
  };

    BlobinfoList: Blobinfo[]= []; 

      columnsDefination: ColDef[]  ;
  rowData$ : Observable<Blobinfo[]> =of([]); ;
  alive: boolean;
// gridApi and columnApi
private api!: GridApi;

  constructor( private blobdataService:BlobdataService) {

     this.alive=true;
    this.columnsDefination=this. createcolumnDef();
   }

   

  ngOnInit() : void {
    this.blobdataService.getBlobData().subscribe(
      (response) => {
        this.rowData$ = of( response);
        const jsonString = JSON.stringify(this. rowData$);
        console.log(jsonString);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  onGridReady(params:any): void {
    this.api = params.api;

    this.api.sizeColumnsToFit();
}



  private createcolumnDef()
  {
return [
  {headerName: 'PropertyId', field: 'propertyId',  sortable: true },
  {headerName: 'PropertyName', field: 'propertyName' ,  sortable: true  },
  {headerName: 'features', field: 'features' ,  valueGetter: (params: ValueGetterParams) => {
    //console.log(  JSON.stringify(params.data.features));
    if (params.data && params.data.features) {
      
      return params.data.features.join(', ');
    }
    return '';
      }
  },
    {headerName: 'highlights', field: 'highlights' ,  valueGetter: (params: ValueGetterParams) => {
    //console.log(  JSON.stringify(params.data.highlights));
    if (params.data && params.data.highlights) {
      
      return params.data.highlights.join(', ');
    }
    return '';
      }
  },

  

]
  
  }

//   detailCellRendererParams = {
//   detailGridOptions: {
//     columnDefs: [
//       { headerName: 'Type', field: 'type' },
//       { headerName: 'Line', field: 'line' },
//       { headerName: 'Distance', field: 'distance' },
//       { headerName: 'Station', field: 'station' },
//     ],
//     defaultColDef: {
//       flex: 1,
//       minWidth: 100,
//       resizable: true
//     }
//   },
//   getDetailRowData: function (params: any) {
//     // Provide transportation data as detail grid data
//     params.successCallback(params.data.transportation || []);
//   }
// };

}