import { Component, OnInit,Output, EventEmitter } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-admin-search',
  templateUrl: './admin-search.component.html',
  styleUrls: ['./admin-search.component.css']
})
export class AdminSearchComponent implements OnInit {
  @Output() newSearchEvent = new EventEmitter<{searchType: string, searchInput: string}>();
  @Output() newShowAllEvent = new EventEmitter();
  ngSelect = "userName";
  searchBy: string ='userName';
  public searchParam: string = '';
  constructor() { }

  ngOnInit(): void {
  }

  onSelect(event: MatSelectChange) {
    this.searchBy = event.value;
  }

  onSearchClick(event: Event){
    this.newSearchEvent.emit({searchType: this.searchBy, searchInput: this.searchParam});
  }

  onShowAllClick(event: Event){
    this.newShowAllEvent.emit();
  }
}
