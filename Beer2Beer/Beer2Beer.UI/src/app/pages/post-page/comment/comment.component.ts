import { Component, Input } from '@angular/core';
import { Comment } from 'src/app/shared/models/comment.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})

export class CommentComponent {
  @Input() comment!: Comment;
  @Input() avatarImage!: any;

  constructor(private readonly router:Router){

  }

  clickProfile(){
    var route = '/user/' + this.comment.user.id
    this.router.navigate([route]);
  }
}
