import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styles: []
})
export class ValueComponent implements OnInit {
  valuesfromApi : any;

  constructor(private myHttp: HttpClient) { }

  ngOnInit() {
    this.myHttp.get('http://localhost:5000/api/values').subscribe((response: any) => {
      this.valuesfromApi = response;    
    }, error => { console.log('Error'); });
  }
}
