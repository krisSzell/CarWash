import { Service } from 'app/components/services/service';
import { ReservationDate } from './date';

export class Reservation {
    reservationId: number;
    service: Service;
    date: ReservationDate;
    username: string;
}