import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlobdataService {

private apiUrl = 'http://localhost:5289/api/NewmarkIndiaBlob/GetBlobResponse/v1'; // Replace with your API endpoint

  constructor(private http: HttpClient) { }

  getBlobData(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

}
