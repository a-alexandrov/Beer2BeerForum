import { Component, Input, OnInit } from '@angular/core';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {MatChipInputEvent} from '@angular/material/chips';

@Component({
  selector: 'app-post-tags',
  templateUrl: './post-tags.component.html',
  styleUrls: ['./post-tags.component.css']
})
export class PostTagsComponent implements OnInit {
  @Input() tags!: string[];
  @Input() disableEdit!: boolean;
  visible = true;
  selectable = !this.disableEdit;
  removable = !this.disableEdit;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  constructor() { }
  
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;
  
    if ((value || '').trim()) {
      this.tags.push(value.toLowerCase());
    }
  
    if (input) {
      input.value = '';
    }
  }

  remove(tag: string): void {
    const index = this.tags.indexOf(tag);
  
    if (index >= 0) 
    {
      this.tags.splice(index, 1);
    }
  }

  ngOnInit(): void {
  }
}
