import { ReservationDate } from './../date';
import { Reservation } from './../reservation';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ReservationService {

  private reservationSource = new BehaviorSubject<Reservation>(new Reservation());
  currentReservationState = this.reservationSource.asObservable();

  constructor() { }

  updateService(serviceId: number) {
    let updated = this.reservationSource.value;
    updated.serviceId = serviceId;
    this.reservationSource.next(updated);
  }

  updateDate(date: ReservationDate) {
    let updated = this.reservationSource.value;
    updated.date = date;
    this.reservationSource.next(updated);
  }
}
