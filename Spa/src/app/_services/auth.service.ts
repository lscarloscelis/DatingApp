import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { login } from '../_models/auth/login';
import { register } from '../_models/auth/register';
import { map } from 'rxjs/operators';
import { token } from '../_models/auth/token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private myHttp: HttpClient) { }
  baseUrl = 'http://localhost:5000/api/auth';
  login(myModel: login) {
    return this.myHttp.post(this.baseUrl + '/login', myModel).pipe(
      map(
        (response: token) => {
          localStorage.setItem('myToken',response.myToken);
        }
      )
    );
  }

  register(myModel: register) {
    return this.myHttp.post(this.baseUrl + '/register', myModel).pipe(
      map(
        () => {
          console.log('Registro OK');
        }
      )
    );
  }
}
