import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: []
})
export class NavComponent implements OnInit {
  constructor(private myRoutes: Router) { }

  ngOnInit() {
    localStorage.removeItem('myToken');
  }

  register() {
    this.myRoutes.navigate(['/register']);
  }

  login() {
    this.myRoutes.navigate(['/login']);
  }

  inicio() {
    this.myRoutes.navigate(['/home']);
  }
}