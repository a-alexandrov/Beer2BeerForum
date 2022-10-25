import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: "root" })
export class StatisticsService {
    private apiPath: string = 'https://localhost:44305/api/statistics';
    private httpHeaders = new HttpHeaders({
        'Content-Type': 'application/json'
    });
    constructor(private httpClient: HttpClient) {
    }

    getUserCount(): Observable<number> {
        return this.httpClient.get<number>(`${this.apiPath}/userCount`, {
            headers: this.httpHeaders
        })
    }
    getPostCount(): Observable<number> {
      return this.httpClient.get<number>(`${this.apiPath}/postCount`, {
          headers: this.httpHeaders
      })
  }
}