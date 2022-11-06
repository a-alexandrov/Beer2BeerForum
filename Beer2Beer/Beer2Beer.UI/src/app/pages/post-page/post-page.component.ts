import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { ActivatedRoute } from '@angular/router';
import { PostLike } from 'src/app/shared/models/post-like.model';

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
    this.getPostById(parseInt(this.postId));
  }

  getPostById(id: number): void {
    this.postsService.getPostById(id)
    .pipe(takeUntil(this.notifier))
      .subscribe((post) => {
        this.post = post;
        this.avatarImage = this.imageService
        .getImageFromByteArray(post.avatarImage, post.imageType);
      })
  }

  onLikeChange(event: { likeValue: boolean; userId: number }): void {
    const postLike: PostLike = new PostLike(event.userId, this.postId, event.likeValue);
      this.postsService.likePost(postLike)
      .pipe(takeUntil(this.notifier))
      .subscribe((likes) => {
        const hmm = likes;
        
        this.post.likes = likes.likes;
        this.post.postLikes = likes.postLikes;
        this.post.postDislikes = likes.postDislikes;
      });
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
