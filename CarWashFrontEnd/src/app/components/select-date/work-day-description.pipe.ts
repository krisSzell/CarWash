import { WorkDay } from './work-day';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'describe' })
export class WorkDayPipe implements PipeTransform {
    transform(value: WorkDay): string {
        var day = value.day;
        var month = value.month;
        if (parseInt(value.day.toString()) < 10) {
            day = "0" + value.day;
        }
        if (parseInt(value.month.toString()) < 10) {
            month = "0" + value.month;
        }
        return day + "." + month;
    }
}