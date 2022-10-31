import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-post-thumbnail',
  templateUrl: './post-thumbnail.component.html',
  styleUrls: ['./post-thumbnail.component.css']
})


export class PostThumbnailComponent implements OnInit {

  @Input () post: Post = new Post;
  

  constructor(public readonly imageService: Imageservice, private router: Router) { }

  ngOnInit(): void {

  }

  onClick(){
    var route = "/post/" + this.post.id;
    this.router.navigate([route]);
  }

}
