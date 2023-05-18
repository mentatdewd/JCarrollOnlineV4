import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MicroPostFeedComponent } from './micro-post-feed.component';

describe('MicroPostFeedComponent', () => {
  let component: MicroPostFeedComponent;
  let fixture: ComponentFixture<MicroPostFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MicroPostFeedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MicroPostFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
