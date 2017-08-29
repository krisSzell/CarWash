import { ReservationDate } from './date';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'resDate' })
export class ReservationDatePipe implements PipeTransform {
    transform(value: ReservationDate, args: any[]): string {
        var arg1 = args[0];
        var year = value.year;
        var day = value.day;
        var month = value.month;
        var hour = value.hour;
        if (parseInt(value.day.toString()) < 10) {
            day = "0" + value.day;
        }
        if (parseInt(value.month.toString()) < 10) {
            month = "0" + value.month;
        }
        return year + arg1 + month + arg1 + day + " at " + hour;
    }
}