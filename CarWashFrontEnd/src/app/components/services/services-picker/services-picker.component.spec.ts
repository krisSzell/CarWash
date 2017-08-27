import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesPickerComponent } from './services-picker.component';

describe('ServicesPickerComponent', () => {
  let component: ServicesPickerComponent;
  let fixture: ComponentFixture<ServicesPickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServicesPickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicesPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
