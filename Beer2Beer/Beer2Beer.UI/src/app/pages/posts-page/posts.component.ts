import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
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
  panelOpenState = false;
  pageEvent!: PageEvent;
  pageIndex: number = 0;
  pageSize: number = 10;
  lowValue: number = 0;
  highValue: number = this.pageSize;
  notifier = new Subject<void>;
  postList !: Post[]
  dataSource !: MatTableDataSource<Post>;
  query: string = "";
  keyword: string = "";
  minComments:string="";
  maxComments:string="";
  minLikes:string="";
  maxLikes:string="";
  minDislikes:string="";
  maxDislikes:string="";

  queryForm = new FormGroup({
    keyword: new FormControl(''),
    minComments:new FormControl(''),
    maxComments:new FormControl(''),
    minLikes:new FormControl(''),
    maxLikes:new FormControl(''),
    minDislikes:new FormControl(''),
    maxDislikes:new FormControl('')
  });

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private readonly postsService: PostsService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts() {

    this.ConstructQueryString();

    return this.postsService.get(this.query)
      .pipe(takeUntil(this.notifier))
      .subscribe(posts => {
        this.postList = posts,
          this.dataSource = new MatTableDataSource(this.postList),
          this.dataSource.paginator = this.paginator
      })
  }

  getPaginatorData(event: PageEvent) {

    if (event.pageIndex === this.pageIndex + 1) {
      this.lowValue = this.lowValue + this.pageSize;
      this.highValue = this.highValue + this.pageSize;
    }
    else if (event.pageIndex === this.pageIndex - 1) {
      this.lowValue = this.lowValue - this.pageSize;
      this.highValue = this.highValue - this.pageSize;
    }
    this.pageIndex = event.pageIndex;
    return this.pageEvent;
  }
  ConstructQueryString() {

    this.query="";
    this.keyword = this.queryForm.value.keyword ?? "";
    this.minComments = this.queryForm.value.minComments??"";
    this.maxComments = this.queryForm.value.maxComments??"";
    this.minLikes = this.queryForm.value.minLikes??"";
    this.maxLikes = this.queryForm.value.maxLikes??"";
    this.minDislikes = this.queryForm.value.minDislikes??"";
    this.maxDislikes = this.queryForm.value.maxDislikes??"";


    var queryParam:string[]=[];

    if(this.keyword){
      queryParam.push("keyword="+this.keyword);
    }
    if(this.minComments){
      queryParam.push("minComments="+this.minComments);
    }
    if(this.maxComments){
      queryParam.push("maxComments="+this.maxComments);
    }
    if(this.minLikes){
      queryParam.push("minLikes="+this.minLikes);
    }
    if(this.maxLikes){
      queryParam.push("maxLikes="+this.maxLikes);
    }
    if(this.minDislikes){
      queryParam.push("minDislikes="+this.minDislikes);
    }
    if(this.maxDislikes){
      queryParam.push("maxDislikes="+this.maxDislikes);
    }

    if (queryParam) {
      this.query += "?" + queryParam.join('&');
    }
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }

}
