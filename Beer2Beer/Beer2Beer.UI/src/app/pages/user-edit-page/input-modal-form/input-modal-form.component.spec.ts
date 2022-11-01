import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputModalFormComponent } from './input-modal-form.component';

describe('InputModalFormComponent', () => {
  let component: InputModalFormComponent;
  let fixture: ComponentFixture<InputModalFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputModalFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputModalFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
