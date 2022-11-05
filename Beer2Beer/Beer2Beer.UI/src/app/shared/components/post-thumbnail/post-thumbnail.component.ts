import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/post.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';


@Component({
  selector: 'app-post-thumbnail',
  templateUrl: './post-thumbnail.component.html',
  styleUrls: ['./post-thumbnail.component.css']
})


export class PostThumbnailComponent implements OnInit {

  @Input () post: Post = new Post;
  

  constructor(public readonly imageService: Imageservice, private router: Router,private auth:AuthenticationService) { }

  ngOnInit(): void {

  }

  onClick(){
    var route = "/post/" + this.post.id;
    this.router.navigate([route]);
  }

  editPost(){
    var route = "/post/edit/"+this.post.id;
    this.router.navigate([route]);
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
}
