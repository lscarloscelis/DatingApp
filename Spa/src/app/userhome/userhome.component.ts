import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FileUploader } from 'ng2-file-upload';
import { UserService } from '../_services/user.service';
import { fotos } from '../_models/fotos/foto';

@Component({
  selector: 'app-userhome',
  templateUrl: './userhome.component.html',
  styles: []
})
export class UserhomeComponent implements OnInit {
  helper = new JwtHelperService();
  currentUser: string;
  currenttId: any;
  mainUrl: string;
  description: string;
  uploader:FileUploader;
  hasBaseDropZoneOver = false;
  response:string;
  baseUrl = 'http://localhost:5000/api/';

  constructor(private myService: UserService) { }

  ngOnInit() {
    var decodedToken = this.helper.decodeToken(localStorage.getItem('myToken'));
    this.currenttId = decodedToken.nameid;
    this.currentUser = decodedToken.unique_name;
    this.myService.getMainUrl(this.currenttId).subscribe(
      (response: fotos) => { this.mainUrl = response.url; this.description = response.descripcion; }
    );
    this.inicializarUploader();
  }

  inicializarUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + this.helper.decodeToken(localStorage.getItem('myToken')).nameid + '/fotos',
      authToken: 'Bearer ' + localStorage.getItem('myToken'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10*1024*1024
    });
    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false;};
  }

  public fileOverBase(e:any):void {
    this.hasBaseDropZoneOver = e;
  }

}
