import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';


@Component({
  selector: 'app-post-thumbnail',
  templateUrl: './post-thumbnail.component.html',
  styleUrls: ['./post-thumbnail.component.css']
})


export class PostThumbnailComponent implements OnInit {

  @Input () post: Post = new Post;

  panelOpenState : boolean= false;

  constructor(public readonly imageService: Imageservice) { }

  ngOnInit(): void {

  }

}
