import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject, takeUntil } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Imageservice } from 'src/app/core/services/image.service';
import { PostsService } from 'src/app/core/services/posts.service';
import { PostUpdate } from 'src/app/shared/models/post-update.model';
import { Post } from 'src/app/shared/models/post.model';

@Component({
  selector: 'app-post-edit-page',
  templateUrl: './post-edit-page.component.html',
  styleUrls: ['./post-edit-page.component.css']
})
export class PostEditPageComponent implements OnInit {

  notifier = new Subject<void>;
  post!:Post;
  postId!:number;
  postContent:string="";
  postTitle:string="";
  avatarImage: any;
  editorRole!: string;
  minTitleLen: number = 16;
  maxTitleLen: number = 64;
  minContentLen: number = 32;
  maxContentLen: number = 8192;

  postEditForm = new FormGroup({
    title: new FormControl('',Validators.required),
    content: new FormControl('',Validators.required),
  });

  constructor(private postService:PostsService,
    private activatedRoute : ActivatedRoute,
    public readonly imageService: Imageservice,
    private auth:AuthenticationService,
    private router:Router) { }

  ngOnInit(): void {
    this.postId = parseInt(this.activatedRoute.snapshot.paramMap.get('id')??"");
    this.getPost();
    this.editorRole = this.auth.getRole();
  }

  getPost(){
    this.postService
      .getPostById(this.postId)
      .pipe(takeUntil(this.notifier))
      .subscribe((p) => {

        if(p.userID!=this.auth.getID() && this.editorRole !== 'Admin'){
          this.router.navigate(['']);
          return;
        }

        this.post = p;
        this.postTitle=p.title;
        this.postContent=p.content;
        this.avatarImage=this.imageService.getImageFromByteArray(p.avatarImage,p.imageType)
      });
  }

  deletePost(){
    this.postService.delete(this.post.id)
    .pipe(takeUntil(this.notifier))
    .subscribe(()=>this.router.navigate(['/']));
  }


  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }


  submit(){
    var route = "/post/" + this.post.id;
    
    var postUpdate: PostUpdate={
      id:this.post.id,
      userID:this.post.userID,
      title:this.postEditForm.value.title ?? this.post.title,
      content:this.postEditForm.value.content ?? this.post.content,
      tags:this.post.tags
    };

    this.postService.put(postUpdate).pipe(takeUntil(this.notifier)).subscribe(()=>this.router.navigate([route]));
    
  }

  isDeletable():boolean{

    if(this.auth.isLogged()){

      if(this.post){
        if(this.auth.getID()==this.post.userID||
        this.auth.isAdmin()){
          return true;
        }
      }
      
    }
    return false;
  }
  

}
