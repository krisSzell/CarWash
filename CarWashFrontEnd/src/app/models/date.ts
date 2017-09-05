export class ReservationDate {
    year: string;
    month: string;
    day: string;
    hour: string;

    toString() {
        return this.year + "." + this.month + "." + this.day + " " + this.hour;
    }
}