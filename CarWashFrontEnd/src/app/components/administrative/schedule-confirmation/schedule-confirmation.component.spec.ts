import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleConfirmationComponent } from './schedule-confirmation.component';

describe('ScheduleConfirmationComponent', () => {
  let component: ScheduleConfirmationComponent;
  let fixture: ComponentFixture<ScheduleConfirmationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScheduleConfirmationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
