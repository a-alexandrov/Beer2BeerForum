import { Injectable } from '@angular/core';
import { UserLogin } from 'src/app/shared/models/user-login.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiPath: string = 'https://localhost:44305/api/login';
  constructor(private http: HttpClient,private router:Router) { }

  post(user:UserLogin){
    this.http.post<any>(this.apiPath,user )
    .subscribe(response => 
    {
      localStorage.setItem ('token', response.token);
      this.router.navigate([''])
    }
    )
  }
}
