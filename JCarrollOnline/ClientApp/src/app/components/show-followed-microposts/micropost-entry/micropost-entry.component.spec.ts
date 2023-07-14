import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MicropostEntryComponent } from './micropost-entry.component';

describe('MicropostEntryComponent', () => {
  let component: MicropostEntryComponent;
  let fixture: ComponentFixture<MicropostEntryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MicropostEntryComponent]
    });
    fixture = TestBed.createComponent(MicropostEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
