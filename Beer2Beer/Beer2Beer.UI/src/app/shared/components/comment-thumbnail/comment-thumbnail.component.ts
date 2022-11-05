import { Component, Input, OnInit } from '@angular/core';
import { Imageservice } from 'src/app/core/services/image.service';
import { Comment } from '../../models/comment.model';

@Component({
  selector: 'app-comment-thumbnail',
  templateUrl: './comment-thumbnail.component.html',
  styleUrls: ['./comment-thumbnail.component.css']
})
export class CommentThumbnailComponent implements OnInit {

  @Input() comment : Comment = new Comment()
  @Input() commenterName !: string

  constructor(public readonly imageService: Imageservice) { }

  ngOnInit(): void {
  }

}
