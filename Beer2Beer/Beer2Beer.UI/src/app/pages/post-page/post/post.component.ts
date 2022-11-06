import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Post } from '../../../shared/models/post.model';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent {
  @Output() likeChangeEvent = new EventEmitter();
  @Input() post!: Post;
  @Input() avatarImage!: any;

  // TODO: fix auth.getID
  currentUserId: number = this.auth.getID();
  userId !: number;
  userLike: boolean | undefined;

  constructor(private router: Router, private auth: AuthenticationService) { }

  ngOnInit(): void {
    this.userLike = this.post.likes.find(l => l.userId === this.currentUserId)?.isLiked;
  }
  
  ngAfterViewInit(): void {
    this.userId = this.post.userID
  }

  clickProfile(): void {
      var route = "/user/" + this.post.userID;
      this.router.navigate([route]);
  }

  onLikeChange(like: boolean): void {
      this.likeChangeEvent.emit({likeValue: like, userId: this.currentUserId});
  }
}

