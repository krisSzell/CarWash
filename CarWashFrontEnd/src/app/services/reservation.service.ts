import { Service } from 'app/components/services/service';
import { ReservationDate } from '../models/date';
import { Reservation } from '../models/reservation';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ReservationService {

  private reservationSource = new BehaviorSubject<Reservation>(new Reservation());
  currentReservationState = this.reservationSource.asObservable();

  constructor() { }

  updateService(service: Service) {
    let updated = this.reservationSource.value;
    updated.service = service;
    this.reservationSource.next(updated);
  }

  updateDate(date: ReservationDate) {
    let updated = this.reservationSource.value;
    updated.date = date;
    this.reservationSource.next(updated);
  }
}
