import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserLogin } from 'src/app/shared/models/user-login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  token:any;
  constructor(private loginservice:LoginService,private jwt:JwtHelperService) { }

  login(user:UserLogin){
    this.loginservice.post(user);
  }

  logout(){
    localStorage.clear();
  }

  getToken(){
    this.token = localStorage.getItem('token');
    var decodedToken = this.jwt.decodeToken(this.token);
    return decodedToken;
  }

  getStatus(){
    return this.getToken().UserStatus;
  }

  getRole(){
    return this.getToken().UserRole;
  }
  
  getID(){
    return this.getToken().UserID;
  }


}
