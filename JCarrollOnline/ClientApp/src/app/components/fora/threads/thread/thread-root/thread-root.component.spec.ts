import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreadRootComponent } from './thread-root.component';

describe('ThreadRootComponent', () => {
  let component: ThreadRootComponent;
  let fixture: ComponentFixture<ThreadRootComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ThreadRootComponent]
    });
    fixture = TestBed.createComponent(ThreadRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
