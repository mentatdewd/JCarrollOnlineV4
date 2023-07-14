import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateForumComponent } from './create.component';

describe('CreateComponent', () => {
  let component: CreateForumComponent;
  let fixture: ComponentFixture<CreateForumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateForumComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateForumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});