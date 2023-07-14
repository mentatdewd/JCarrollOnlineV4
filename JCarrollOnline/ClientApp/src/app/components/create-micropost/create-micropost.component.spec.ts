import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMicropostComponent } from './create-micropost.component';

describe('CreateMicropostComponent', () => {
  let component: CreateMicropostComponent;
  let fixture: ComponentFixture<CreateMicropostComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateMicropostComponent]
    });
    fixture = TestBed.createComponent(CreateMicropostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
