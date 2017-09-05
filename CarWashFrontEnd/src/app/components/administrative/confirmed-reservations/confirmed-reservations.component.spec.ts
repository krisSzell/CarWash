import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmedReservationsComponent } from './confirmed-reservations.component';

describe('ConfirmedReservationsComponent', () => {
  let component: ConfirmedReservationsComponent;
  let fixture: ComponentFixture<ConfirmedReservationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmedReservationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmedReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
