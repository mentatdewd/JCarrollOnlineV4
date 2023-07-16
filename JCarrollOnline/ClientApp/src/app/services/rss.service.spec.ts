import { TestBed } from '@angular/core/testing';

import { RSSService } from './rss.service';

describe('RSSService', () => {
  let service: RSSService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RSSService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
