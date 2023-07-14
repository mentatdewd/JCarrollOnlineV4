import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFollowedMicropostsComponent } from './show-followed-microposts.component';

describe('ShowMicropostsComponent', () => {
  let component: ShowFollowedMicropostsComponent;
  let fixture: ComponentFixture<ShowFollowedMicropostsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowFollowedMicropostsComponent]
    });
    fixture = TestBed.createComponent(ShowFollowedMicropostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
