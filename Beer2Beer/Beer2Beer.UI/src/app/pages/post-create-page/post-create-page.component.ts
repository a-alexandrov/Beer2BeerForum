import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Subject, takeUntil } from 'rxjs';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { PostsService } from 'src/app/core/services/posts.service';
import { PostCreate } from 'src/app/shared/models/post-create.model';

@Component({
  selector: 'app-post-create-page',
  templateUrl: './post-create-page.component.html',
  styleUrls: ['./post-create-page.component.css']
})
export class PostCreatePageComponent implements OnInit {
  notifier = new Subject<void>;
  route = "/post/";
  postCreateForm = new FormGroup({
    title: new FormControl('',Validators.required),
    content: new FormControl('',Validators.required),
  });

  constructor(private auth:AuthenticationService,
    private postService:PostsService,
    private router:Router) { }

  ngOnInit(): void {
  }
  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }

  submit(){

    var postCreate:PostCreate={
      
      userID:this.auth.getID(),
      title:this.postCreateForm.value.title??"",
      content:this.postCreateForm.value.content??"",

    };

    this.postService.post(postCreate).pipe(takeUntil(this.notifier)).subscribe(p=>{
      this.route+=p.id;
      this.router.navigate([this.route]);
    })


  }

  

}
