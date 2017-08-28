import { Reservation } from './../../../reservation';
import { WorkDay } from './../work-day';
import { WorkDaysService } from './../../../services/work-days.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-work-days-picker',
  templateUrl: './work-days-picker.component.html',
  styleUrls: ['./work-days-picker.component.css']
})
export class WorkDaysPickerComponent implements OnInit {

  workDays = [];
  selectedDay;
  daysLoaded = false;
  @Output() onDateSelected: EventEmitter<any> = new EventEmitter();

  constructor(private _service: WorkDaysService) { }

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

  selectHour($event) {
    let reservation = this.setReservationDate(
      this.selectedDay.year, this.selectedDay.month,
      this.selectedDay.day, $event.toElement.innerText);

    this.onDateSelected.emit(reservation);
    console.log(reservation);
  }

  setReservationDate(year: string, month: string, day: string, hour: string) {
    let reservation = {
      serviceId: null,
      date: {
        year: year,
        month: month,
        day: day,
        hour: hour
      },
      userId: ""
    };
    return reservation;
  }
}
