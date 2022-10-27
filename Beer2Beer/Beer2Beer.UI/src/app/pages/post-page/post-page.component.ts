import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.css']
})

export class PostPageComponent implements OnInit, OnDestroy {
  notifier = new Subject<void>;
  post!: Post;
  avatarImage: any;
  
  constructor(private readonly postsService: PostsService, private sanitizer: DomSanitizer) { 
  }

  ngOnInit(): void {
    this.getPostById(1);
  }

  getPostById(id: number) {
    this.postsService.getPostById(id)
    .pipe(takeUntil(this.notifier))
      .subscribe((post) => {
        this.post = post;
        //GET DB ENTRY FOR FILE NAME!
        let objectURL = 'data:image/jpg;base64,' + post.avatarImage;
        this.avatarImage = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      })
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
