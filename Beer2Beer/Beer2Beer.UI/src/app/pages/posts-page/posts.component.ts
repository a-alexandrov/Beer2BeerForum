import { Component, OnInit,ViewChild } from '@angular/core';
import { MatPaginator,PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subject, takeUntil } from 'rxjs';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from 'src/app/shared/models/post.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  pageEvent!:PageEvent;
  pageIndex:number = 0;
  pageSize:number = 10;
  lowValue:number = 0;
  highValue:number = this.pageSize; 
  notifier = new Subject<void>;
  postList !: Post[]
  dataSource !: MatTableDataSource<Post>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(private readonly postsService: PostsService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    return this.postsService.getPosts()
    .pipe(takeUntil(this.notifier))
    .subscribe(posts => {
      this.postList=posts,
      this.dataSource=new MatTableDataSource(this.postList),
      this.dataSource.paginator=this.paginator})
  }

  getPaginatorData(event:PageEvent){

    if(event.pageIndex === this.pageIndex + 1){
       this.lowValue = this.lowValue + this.pageSize;
       this.highValue =  this.highValue + this.pageSize;
      }
   else if(event.pageIndex === this.pageIndex - 1){
      this.lowValue = this.lowValue - this.pageSize;
      this.highValue =  this.highValue - this.pageSize;
     }   
      this.pageIndex = event.pageIndex;
      return this.pageEvent;
}
  ngOnDestroy() : void{
    this.notifier.next();
    this.notifier.complete();
  }

}
