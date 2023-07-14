import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JcolNavbarComponent } from './jcol-navbar.component';

describe('JcolNavbarComponent', () => {
  let component: JcolNavbarComponent;
  let fixture: ComponentFixture<JcolNavbarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [JcolNavbarComponent]
    });
    fixture = TestBed.createComponent(JcolNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
