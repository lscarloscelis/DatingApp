import { Component, OnInit } from '@angular/core';
import { login } from '../_models/auth/login';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  toLogin: login = {
    nombre: '',
    clave: ''
  };
  constructor(private myService: AuthService, private myRouter: Router) { }

  ngOnInit() {
  }

  login(myForm: NgForm) {
    return this.myService.login(this.toLogin).subscribe(
      () => {
        myForm.reset(); this.myRouter.navigate(['/userhome']);
      }, error => { console.log('Error'); }
    );
  }
}
