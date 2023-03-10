import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserLogin } from 'src/app/shared/models/user-login.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  token:any;
  constructor(private loginservice:LoginService,private jwt:JwtHelperService,private router:Router) { }

  login(user:UserLogin){
    this.loginservice.post(user);
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate([''])
  }
//refactor get token,decode token, etc
  getToken(){
    this.token = localStorage.getItem('token');
    var decodedToken = this.jwt.decodeToken(this.token);
    return decodedToken;
  }

  getJWT(){
    return localStorage.getItem('token');
  }

  getStatus(){
    return this.getToken()?this.getToken().UserStatus:null;
  }

  getRole(){
    return this.getToken()?this.getToken().UserRole:null;
  }

  isAdmin(): boolean {
    if(this.getRole()=="Admin"){
      return true;
    }
    return false;
  }
  
  getID() : number{
    return (this.getToken()?this.getToken().UserID:null);
  }

  getExpiryTime(){
    return this.getToken()?this.getToken().exp:null;
  }

  isTokenExpired(): boolean {
    const expiryTime: number = this.getExpiryTime();
    if (expiryTime) {
      return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
    } else {
      return false;
    }
  }
  
  validateExpTime(){
    if(this.isTokenExpired()){
      this.logout();
      this.router.navigate([''])
    }
  }

  showActiveUser(){

    this.token = localStorage.getItem('token');
    if(!this.isLogged()){
      alert("No active user!")
    }
    else{
      alert( this.getRole()+" with ID: "+ this.getID() + " and status: " + this.getStatus() +", token expired:"+ this.isTokenExpired())
    }

  }

  isLogged():boolean{

    this.token = localStorage.getItem('token');

    return this.token?true:false;
    
  }

}
