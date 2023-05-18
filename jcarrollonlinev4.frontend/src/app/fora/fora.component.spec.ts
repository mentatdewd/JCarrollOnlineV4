import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForaComponent } from './fora.component';

describe('ForaComponent', () => {
  let component: ForaComponent;
  let fixture: ComponentFixture<ForaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
