import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }
  title = "Beer2Beer Forum"
  description = "A forum devoted to beer cicerones."
  ngOnInit(): void {
  }

}
