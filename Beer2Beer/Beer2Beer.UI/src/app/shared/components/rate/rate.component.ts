import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
})
export class RateComponent implements OnInit {
  @Input() public isLiked!: boolean | undefined
  @Output() likeChangeEvent = new EventEmitter();

  onClick(isLiked: boolean) {
    console.log(`onclick from rate.components sends ${isLiked}`);
    this.isLiked = isLiked;
    this.likeChangeEvent.emit(this.isLiked);
  }

  ngOnInit(): void {
  }

}
