import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsComicComponent } from './details-comic.component';

describe('DetailsComicComponent', () => {
  let component: DetailsComicComponent;
  let fixture: ComponentFixture<DetailsComicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailsComicComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsComicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
