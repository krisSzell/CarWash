import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  nextStep($event) {
    console.log(new Date().getMonth());
    console.log($event);
  }

}
