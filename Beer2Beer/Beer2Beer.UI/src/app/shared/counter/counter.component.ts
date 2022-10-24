import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {
  type = "users"
  count = 100000;
  constructor() { }

  ngOnInit(): void {
  }

}
