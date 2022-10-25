import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {

  constructor() { }

  username:string = "BeerUser"
  role:string = "User"
  firstName:string = "Beer"
  lastName:string = "User"
  joinDate:string = "1991.7.19"
  postCount:number = 44

  ngOnInit(): void {
  }

}
