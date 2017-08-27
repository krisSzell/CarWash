import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkDaysPickerComponent } from './work-days-picker.component';

describe('WorkDaysPickerComponent', () => {
  let component: WorkDaysPickerComponent;
  let fixture: ComponentFixture<WorkDaysPickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkDaysPickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkDaysPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
