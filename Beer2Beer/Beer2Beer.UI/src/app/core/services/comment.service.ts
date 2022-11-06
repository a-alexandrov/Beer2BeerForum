import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommentCreate } from '../../shared/models/comment-create.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
export class CommentService{
  private apiPath: string = "https://localhost:44305/api/comments"

  constructor(private httpClient: HttpClient) { 
}
post(comment: CommentCreate){
    return this.httpClient.post<CommentCreate>(this.apiPath, comment)
}
}