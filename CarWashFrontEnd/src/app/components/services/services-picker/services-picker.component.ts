import { Reservation } from './../../../reservation';
import { ReservationService } from './../../../services/reservation.service';
import { ServicesService } from './../../../services/services.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Service } from "app/components/services/service";

@Component({
  selector: 'app-services-picker',
  templateUrl: './services-picker.component.html',
  styleUrls: ['./services-picker.component.css']
})
export class ServicesPickerComponent implements OnInit {

  reservation: Reservation;
  services = [];

  constructor(private _servicesService: ServicesService,
    private _reservationService: ReservationService) { }

  ngOnInit() {
    this._servicesService.getServices()
      .subscribe(services => this.services = services);

    this._reservationService.currentReservationState
      .subscribe(reservation => this.reservation = reservation);
  }

  onClick(service: Service) {
    this._reservationService.updateService(service.serviceId);
    console.log(service);
  }
}
