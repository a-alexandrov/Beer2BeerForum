import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor() { }

  title = 'Beer post title';
  content = `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ac tellus pulvinar, egestas metus vel, convallis
  sapien. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed iaculis
  metus non libero facilisis pretium. Quisque consequat sagittis nunc eget suscipit. Sed sagittis dolor eu ornare
  convallis. Praesent accumsan ultricies velit, sed sodales nulla interdum vitae. Interdum et malesuada fames ac
  ante ipsum primis in faucibus. Quisque nec nisi at arcu dictum euismod pellentesque eget dolor. Quisque feugiat
  sem id risus fringilla volutpat. Nulla finibus diam in nisi volutpat sagittis. Morbi aliquet hendrerit tellus
  id iaculis. Suspendisse volutpat id mi ut egestas.`;

  ngOnInit(): void {
  }
}

