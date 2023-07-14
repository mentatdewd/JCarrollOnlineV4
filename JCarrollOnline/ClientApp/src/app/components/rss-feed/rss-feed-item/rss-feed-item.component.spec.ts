import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RssFeedItemComponent } from './rss-feed-item.component';

describe('RssFeedItemComponent', () => {
  let component: RssFeedItemComponent;
  let fixture: ComponentFixture<RssFeedItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RssFeedItemComponent]
    });
    fixture = TestBed.createComponent(RssFeedItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
