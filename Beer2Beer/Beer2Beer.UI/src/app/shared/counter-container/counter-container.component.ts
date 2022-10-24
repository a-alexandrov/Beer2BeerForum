import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-counter-container',
  templateUrl: './counter-container.component.html',
  styleUrls: ['./counter-container.component.css']
})
export class CounterContainerComponent implements OnInit {

  constructor() { }

  postsCount = 18000;
  usersCount=9001;
  ngOnInit(): void {
  }

}
