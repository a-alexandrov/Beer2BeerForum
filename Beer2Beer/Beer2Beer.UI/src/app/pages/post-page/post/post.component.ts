import { Component, OnInit } from '@angular/core';
import { Post } from '../../../shared/models/post.model';
import { Comment } from '../../../shared/models/comment.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit {
  comments: Comment[] = [new Comment(0, 'i love comments', 0, 'beerDrinker'), new Comment(0, 'i hate comments', 0, 'commentGuy')];

  post = new Post(0, 'Beer post title', `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ac tellus pulvinar, egestas metus vel, convallis
  sapien. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed iaculis
  metus non libero facilisis pretium. Quisque consequat sagittis nunc eget suscipit. Sed sagittis dolor eu ornare
  convallis. Praesent accumsan ultricies velit, sed sodales nulla interdum vitae. Interdum et malesuada fames ac
  ante ipsum primis in faucibus. Quisque nec nisi at arcu dictum euismod pellentesque eget dolor. Quisque feugiat
  sem id risus fringilla volutpat. Nulla finibus diam in nisi volutpat sagittis. Morbi aliquet hendrerit tellus
  id iaculis. Suspendisse volutpat id mi ut egestas.`, 0, 0, 0, 0, [], this.comments);



  ngOnInit(): void {
  }
}

