import { WorkDay } from './../work-day';
import { WorkDaysService } from './../../../services/work-days.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-work-days-picker',
  templateUrl: './work-days-picker.component.html',
  styleUrls: ['./work-days-picker.component.css']
})
export class WorkDaysPickerComponent implements OnInit {

  workDays = [];
  selectedDay;
  daysLoaded = false;

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

  select(day: WorkDay) {
    this.workDays.forEach(d => {
      d.isSelected = false;
      if (d == day) {
        d.isSelected = true;
      }
    });
    this.selectedDay = day;
  }
}
