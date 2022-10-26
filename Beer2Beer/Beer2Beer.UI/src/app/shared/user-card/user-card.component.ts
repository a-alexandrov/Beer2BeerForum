import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {

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
