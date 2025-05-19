import { Component, OnInit } from '@angular/core';
import { BlobdataService } from '../../services/blobdata.service';
import { Blobinfo } from '../../classes/blobinfo';

@Component({
  selector: 'app-bobinfo',
  templateUrl: './bobinfo.component.html',
  styleUrls: ['./bobinfo.component.css']
})
export class BobinfoComponent implements OnInit {

    BlobinfoList: Blobinfo[]= []; 
  constructor( private blobdataService:BlobdataService) { }

  ngOnInit() : void {
    this.blobdataService.getBlobData().subscribe(
      (response) => {
        this.BlobinfoList = response;
        const jsonString = JSON.stringify(this.BlobinfoList);
        console.log(jsonString);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

}
