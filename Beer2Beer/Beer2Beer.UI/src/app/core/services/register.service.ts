import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRegister } from 'src/app/shared/models/user-register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiPath: string = 'https://localhost:44305/api/users';
  constructor(private http: HttpClient) { }

  post(user:UserRegister){
    this.http.post<any>(this.apiPath,user ).subscribe();
  }
}
