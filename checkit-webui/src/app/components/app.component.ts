import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: '../templates/app.component.html',
  styleUrls: ['../styles/app.component.css']
})
export class AppComponent implements OnInit {
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

  timestamp = '9999-99-99 99:99:99';

  constructor(private http: HttpClient) {

  }

  // connectivity tests
  ngOnInit(): void {
    this.http.get('http://localhost:9001', { responseType: 'text' }).subscribe(data => {
      console.log(data);
      this.timestamp = data;
    });

    this.http.get('http://localhost:9001/api/NumberToString/Money?value=12345678.90').subscribe(response => {
      console.log(response);
      // alert(response);
    });
  }
}
