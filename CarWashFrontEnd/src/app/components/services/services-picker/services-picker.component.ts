import { ServicesService } from './../../../services/services.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-services-picker',
  templateUrl: './services-picker.component.html',
  styleUrls: ['./services-picker.component.css']
})
export class ServicesPickerComponent implements OnInit {

  services = [];

  constructor(private _servicesService: ServicesService) { }

  ngOnInit() {
    this._servicesService.getServices()
      .subscribe(services => this.services = services);
  }

}
