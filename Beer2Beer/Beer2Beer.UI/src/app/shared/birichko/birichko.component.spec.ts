import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BirichkoComponent } from './birichko.component';

describe('BirichkoComponent', () => {
  let component: BirichkoComponent;
  let fixture: ComponentFixture<BirichkoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BirichkoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BirichkoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
