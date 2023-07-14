import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreadEntryComponent } from './thread-entry.component';

describe('ThreadEntryComponent', () => {
  let component: ThreadEntryComponent;
  let fixture: ComponentFixture<ThreadEntryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ThreadEntryComponent]
    });
    fixture = TestBed.createComponent(ThreadEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
