import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.css']
})

export class PostPageComponent implements OnInit, OnDestroy {
  notifier = new Subject<void>;
  post!: Post;
  avatarImage: any;
  postId!: any;
  
  constructor(
     private readonly postsService: PostsService,
     public readonly imageService: Imageservice,
     private activatedRoute : ActivatedRoute) { 
  }

  ngOnInit(): void {
    this.postId = this.activatedRoute.snapshot.paramMap.get("id");
    console.log(this.postId);
    this.getPostById(parseInt(this.postId));
  }

  getPostById(id: number) {
    this.postsService.getPostById(id)
    .pipe(takeUntil(this.notifier))
      .subscribe((post) => {
        this.post = post;
        this.avatarImage = this.imageService
        .getImageFromByteArray(post.avatarImage, post.imageType);
      })
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
