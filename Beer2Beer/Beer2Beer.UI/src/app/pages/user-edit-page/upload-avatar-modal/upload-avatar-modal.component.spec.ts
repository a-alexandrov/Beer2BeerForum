import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadAvatarModalComponent } from './upload-avatar-modal.component';

describe('UploadAvatarModalComponent', () => {
  let component: UploadAvatarModalComponent;
  let fixture: ComponentFixture<UploadAvatarModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadAvatarModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadAvatarModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
