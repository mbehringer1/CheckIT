import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: '../templates/app.component.html',
  styleUrls: ['../styles/app.component.css']
})
export class AppComponent {
  title = 'CheckIT';
  fullName = 'Random Dude';
  street = '111 The Blvd.';
  city = 'Elmsville';
  state = 'NE';
  zipcode = '11111';
  phoneNumber = '3668225563';
  checkNumber = '1000';
  date = new Date().toLocaleDateString();
  esignature = 'Click here to sign';
}
