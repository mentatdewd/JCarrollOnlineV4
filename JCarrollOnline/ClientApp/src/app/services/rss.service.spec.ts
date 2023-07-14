import { TestBed } from '@angular/core/testing';

import { RSSService } from './rss.service';

describe('RSSSeviceService', () => {
  let service: RSSSeviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RSSSeviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
