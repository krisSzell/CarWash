import { Service } from 'app/components/services/service';
import { ReservationDate } from './date';

export class Reservation {
    service: Service;
    date: ReservationDate;
    username: string;
}