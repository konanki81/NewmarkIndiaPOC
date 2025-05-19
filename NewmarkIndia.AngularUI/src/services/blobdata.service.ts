import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Blobinfo } from '../classes/blobinfo';

@Injectable({
  providedIn: 'root'
})
export class BlobdataService {

private apiUrl = 'http://localhost:5289/api/NewmarkIndiaBlob/GetBlobResponse/v1'; // Replace with your API endpoint

  constructor(private http: HttpClient) { }

  getBlobData(): Observable<Blobinfo[]> {
    return this.http.get<Blobinfo[]>(this.apiUrl);
  }

}
