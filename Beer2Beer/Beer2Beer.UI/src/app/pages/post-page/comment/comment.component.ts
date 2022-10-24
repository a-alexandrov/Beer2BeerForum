import { Component, Input } from '@angular/core';
import { Comment } from 'src/app/shared/models/comment.model';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})

export class CommentComponent{
  @Input() comment!: Comment
}
