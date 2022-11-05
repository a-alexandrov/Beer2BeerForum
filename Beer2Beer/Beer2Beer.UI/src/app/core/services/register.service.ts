import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserRegister } from 'src/app/shared/models/user-register.model';
import { User } from 'src/app/shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiPath: string = 'https://localhost:44305/api/users';
  constructor(private http: HttpClient) { }

  post(user: UserRegister): Observable<User>{
    return this.http.post<User>(this.apiPath,user );
  }
}
