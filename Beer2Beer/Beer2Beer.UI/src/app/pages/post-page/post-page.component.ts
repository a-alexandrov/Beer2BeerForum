import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.css']
})

export class PostPageComponent implements OnInit, OnDestroy {
  notifier = new Subject<void>;
  post!: Post;

  constructor(private readonly postsService: PostsService) { 
  }

  ngOnInit(): void {
    this.getPostById(1);
  }

  getPostById(id: number){
    this.postsService.getPostById(id)
    .pipe(takeUntil(this.notifier))
      .subscribe((post) => {
        this.post = post;
        console.log(post);
      })
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
