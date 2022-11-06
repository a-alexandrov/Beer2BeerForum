import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { CommentService } from 'src/app/core/services/comment.service';
import { CommentCreate } from '../../models/comment-create.model';
import { Subject, takeUntil} from 'rxjs';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})

export class AddCommentComponent implements OnInit {

  notifier = new Subject<void>

  @Input() postId:number = 0

  commentForm = new FormGroup({
    content: new FormControl('',Validators.required)
  })

  constructor(private auth: AuthenticationService, private commentService:CommentService) { }

  ngOnInit(): void {
  }

   async submit(){
    let comment: CommentCreate = new CommentCreate(this.commentForm.value.content ?? "", this.postId, this.auth.getID())
    this.commentService.post(comment).pipe(takeUntil(this.notifier)).subscribe((comment) => comment)
    location.reload()
  }
}
