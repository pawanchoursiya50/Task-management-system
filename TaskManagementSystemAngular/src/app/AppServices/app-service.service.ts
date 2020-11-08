import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  constructor(public http: HttpClient) { }

  login(data){
    return this.http.post("https://localhost:44304/api/v1/login",data);
  }

  register(data){
    return this.http.post("https://localhost:44304/api/v1/user/addUser",data);
  }
}
