import { ReservationDate } from '../../models/date';
import { ReservationService } from './../../services/reservation.service';
import { Reservation } from '../../models/reservation';
import { WorkDay } from '../../models/work-day';
import { WorkDaysService } from './../../services/work-days.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-select-date',
  templateUrl: './select-date.component.html',
  styleUrls: ['./select-date.component.css']
})
export class SelectDateComponent implements OnInit {

  reservation: Reservation;
  workDays = [];
  selectedDay: WorkDay;
  daysLoaded = false;

  constructor(private _service: WorkDaysService,
    private _reservationService: ReservationService) { }

  ngOnInit() {
    this._service.getWorkDays()
      .subscribe(days => this.workDays = days,
      null,
      () => {
        this.workDays.forEach(d => {
          if (d.isSelected) {
            this.selectedDay = d;
          }
        });
        this.daysLoaded = true;
      });

    this._reservationService.currentReservationState
      .subscribe(reservation => this.reservation = reservation);
  }

  selectDay(day: WorkDay) {
    this.workDays.forEach(d => {
      d.isSelected = false;
      if (d == day) {
        d.isSelected = true;
      }
    });
    this.selectedDay = day;
  }

  selectHour(workHour) {
    let date: ReservationDate = new ReservationDate();
    date.hour = workHour;
    date.year = this.selectedDay.year;
    date.month = this.selectedDay.month;
    date.day = this.selectedDay.day;

    this._reservationService.updateDate(date);
  }
}
