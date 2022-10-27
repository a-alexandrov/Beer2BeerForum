import { Injectable } from '@angular/core';
import { UserLogin } from 'src/app/shared/models/userlogin.model';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiPath: string = 'https://localhost:44305/api/login';
  constructor(private http: HttpClient) { }

  post(user:UserLogin){
    this.http.post<any>(this.apiPath,user )
    .subscribe(data => 
    {
      localStorage.setItem ('token', data.token);
    }
    )
  }
}
