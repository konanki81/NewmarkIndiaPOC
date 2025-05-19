/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BlobdataService } from './blobdata.service';

describe('Service: Blobdata', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BlobdataService]
    });
  });

  it('should ...', inject([BlobdataService], (service: BlobdataService) => {
    expect(service).toBeTruthy();
  }));
});
