import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { register } from '../_models/auth/register';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: []
})
export class RegisterComponent implements OnInit {
  toRegister : register = {
    document: '',
    nombre: '',
    clave: ''
  };
  constructor(private myService: AuthService) { }

  ngOnInit() {
  }

  register(myForm: NgForm){
    return this.myService.register(this.toRegister).subscribe(
      () => {
        myForm.reset(); console.log('Registro OK');
      }, error => { console.log('Error'); }
    );
  }
}
