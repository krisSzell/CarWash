import { ServicesService } from './../../../services/services.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Service } from "app/components/services/service";

@Component({
  selector: 'app-services-picker',
  templateUrl: './services-picker.component.html',
  styleUrls: ['./services-picker.component.css']
})
export class ServicesPickerComponent implements OnInit {

  services = [];
  selectedService: Service;
  @Output() onSelected: EventEmitter<Service> = new EventEmitter();

  constructor(private _servicesService: ServicesService) { }

  ngOnInit() {
    this._servicesService.getServices()
      .subscribe(services => this.services = services,
      null,
      () => {
        this.services.forEach(s => s.isSelected = false);
      });
  }

  onClick(service: Service) {
    this.selectedService = service;
    this.services.forEach(s => s.isSelected = false);
    this.services.find(s => s == service).isSelected = true;
  }

  onSelect(service: Service) {
    this.onSelected.emit(service);
  }

}
