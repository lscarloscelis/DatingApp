import { Component, OnInit } from '@angular/core';
import { user } from '../_models/fotos/user';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styles: []
})
export class MatchesComponent implements OnInit {

  usuarios: user[] = [{
    name: '',
    url: ''
  }];
  constructor() { }

  ngOnInit() {
  }

}