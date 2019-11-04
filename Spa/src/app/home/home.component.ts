import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  hideTools: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
