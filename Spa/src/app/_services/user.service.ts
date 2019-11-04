import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = "http://localhost:5000/api/";

  constructor(private myHttp: HttpClient) { }

  getMainUrl(id: string) {
    return this.myHttp.get(this.baseUrl + id + '/fotos', { headers: new HttpHeaders().set('Authorization', 
      'Bearer ' + localStorage.getItem('myToken')) });
  }

  getUsers() {
    
  }
}