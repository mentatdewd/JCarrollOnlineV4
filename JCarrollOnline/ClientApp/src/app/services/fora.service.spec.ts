import { TestBed } from '@angular/core/testing';

import { ForaService } from './fora.service';

describe('ForaService', () => {
  let service: ForaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ForaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
