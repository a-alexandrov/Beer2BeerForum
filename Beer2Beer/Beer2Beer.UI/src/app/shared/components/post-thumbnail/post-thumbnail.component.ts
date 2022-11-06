import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { PostsService } from 'src/app/core/services/posts.service';
import { Subject, takeUntil } from 'rxjs';


@Component({
  selector: 'app-post-thumbnail',
  templateUrl: './post-thumbnail.component.html',
  styleUrls: ['./post-thumbnail.component.css']
})


export class PostThumbnailComponent implements OnInit {
  notifier = new Subject<void>;

  @Input () post: Post = new Post;
  

  constructor(public readonly imageService: Imageservice,
     private router: Router,
     private auth:AuthenticationService,
     private postService:PostsService) { }

  ngOnInit(): void {

  }

  viewPost(){
    var route = "/post/" + this.post.id;
    this.router.navigate([route]);
  }

  editPost(){
    var route = "/post/edit/"+this.post.id;
    this.router.navigate([route]);
  }

  deletePost(){
    this.postService.delete(this.post.id)
    .pipe(takeUntil(this.notifier))
    .subscribe(()=>window.location.reload());
  }
  
  clickProfile(){
    var route = "/user/" + this.post.userID;
    this.router.navigate([route]);
  }

  isEditable():boolean{

    if(this.auth.isLogged()){

      if(this.auth.getID()==this.post.userID){

        return true;
      }
    }
    return false;
  }

  isDeletable():boolean{

    if(this.auth.isLogged()){

      if(this.auth.getID()==this.post.userID||
      this.auth.isAdmin()){
        return true;
      }
    }
    return false;
  }



}
