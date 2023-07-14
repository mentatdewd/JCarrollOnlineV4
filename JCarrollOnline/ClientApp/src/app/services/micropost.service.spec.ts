import { TestBed } from '@angular/core/testing';

import { MicropostService } from './micropost.service';

describe('MicropostService', () => {
  let service: MicropostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MicropostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
