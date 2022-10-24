import { Component, OnInit } from '@angular/core';

declare var name: any;

@Component({
  selector: 'app-birichko',
  templateUrl: './birichko.component.html',
  styleUrls: ['./birichko.component.css']
})
export class BirichkoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    new name();
  }
  title='app=js'

}
