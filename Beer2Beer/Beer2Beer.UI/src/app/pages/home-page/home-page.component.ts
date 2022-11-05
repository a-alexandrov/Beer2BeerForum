import { Component, OnInit , OnDestroy} from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})


export class HomePageComponent implements OnInit {

  notifier = new Subject<void>;
  latestPosts !: Post[]
  mostComentedPosts !: Post[] 

  constructor(private readonly postsService: PostsService) { }

  ngOnInit(): void {
    this.getLatestPosts();
    this.getMostCommentedPosts();
  }

  getLatestPosts(){
    this.postsService
      .getLatest()
      .pipe(takeUntil(this.notifier))
      .subscribe(posts => this.latestPosts = posts)

  }
  getMostCommentedPosts(){
    this.postsService
      .getMostComented()
      .pipe(takeUntil(this.notifier))
      .subscribe(posts => this.mostComentedPosts = posts)

  }

  ngOnDestroy() : void{
    this.notifier.next();
    this.notifier.complete();
  }

}
