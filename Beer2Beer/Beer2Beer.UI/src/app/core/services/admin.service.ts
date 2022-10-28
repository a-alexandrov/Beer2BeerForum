import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../shared/models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiPath: string = "https://localhost:44305/api/admin"

  constructor(private httpClient: HttpClient) { 
  }

  blockUserByUserName(username: string): Observable<User>{
    return this.httpClient.put<User>(`${this.apiPath}/block?username=${username}`, '')
  }

  unblockUserByUserName(username: string): Observable<User>{
    return this.httpClient.put<User>(`${this.apiPath}/unblock?username=${username}`, '')
  }

  promoteUserByUserName(username: string): Observable<User>{
    return this.httpClient.put<User>(`${this.apiPath}/promote?username=${username}`, '')
  }
  
  demoteUserByUserName(username: string): Observable<User>{
    return this.httpClient.put<User>(`${this.apiPath}/demote?username=${username}`, '')
  }
}
