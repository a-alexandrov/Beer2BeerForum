import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../shared/models/user.model';
import { Observable } from 'rxjs';
import { UserUpdate } from 'src/app/shared/models/user-update.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiPath: string = "https://localhost:44305/api/users";
  constructor(private httpClient: HttpClient) { 
  }

  getUserById(id:number): Observable<User>{
    return this.httpClient.get<User>(`${this.apiPath}/${id}`)
  }

  getUsers(): Observable<User[]>{
    return this.httpClient.get<User[]>(this.apiPath)
  }

  updateUser(userUpdate: UserUpdate): Observable<User>{
    return this.httpClient.put<User>(this.apiPath, userUpdate);
  }

  updateUserAvatar(file: File, userId: number): Observable<User>{
    let formData: FormData = new FormData();
    formData.append('avatarImage', file);
    return this.httpClient.put<User>(this.apiPath + `/avatar/${userId}`, formData)
  }
}
