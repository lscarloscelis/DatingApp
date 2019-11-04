import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usernav',
  templateUrl: './usernav.component.html',
  styles: []
})
export class UsernavComponent implements OnInit {

  constructor(private myRouter: Router) { }

  ngOnInit() {
  }

  cerrar() {
    localStorage.removeItem('myToken');
    this.myRouter.navigate(['/home']);
  }

}
