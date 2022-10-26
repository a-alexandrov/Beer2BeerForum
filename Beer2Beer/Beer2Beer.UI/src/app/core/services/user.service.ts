import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../shared/models/user.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiPath: string = "https://localhost:44305/api/user"
  private httpHeaders = new HttpHeaders({
    'Content-Type': 'application/json'
});
  constructor(private httpClient: HttpClient) { 

  }

  getUserById(id:number): Observable<User>{
    return this.httpClient.get<User>(`${this.apiPath}/${id}`, {
      headers: this.httpHeaders})
    }
}