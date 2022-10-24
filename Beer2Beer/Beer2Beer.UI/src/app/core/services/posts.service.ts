import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../../shared/models/post.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: "root" })
export class PostsService {
    private apiPath: string = 'https://localhost:44305/api/posts';
    private httpHeaders = new HttpHeaders({
        'Content-Type': 'application/json'
    });
    constructor(private httpClient: HttpClient) {
    }

    getPostById(id: number): Observable<Post> {
        return this.httpClient.get<Post>(`${this.apiPath}/${id}`, {
            headers: this.httpHeaders
        })
    }
}