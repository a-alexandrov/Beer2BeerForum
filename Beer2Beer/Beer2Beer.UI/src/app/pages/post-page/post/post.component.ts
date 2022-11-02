import { Component, Input } from '@angular/core';
import { Post } from '../../../shared/models/post.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent {
  @Input() post!: Post;
  @Input() avatarImage!: any;

  userId !: number
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  
  ngAfterViewInit():void {
    this.userId = this.post.userID
  }

  clickProfile(){
      var route = "/user/" + this.post.userID;
      this.router.navigate([route]);
  }
}

