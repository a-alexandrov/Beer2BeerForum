import { Component,OnDestroy ,OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { StatisticsService } from 'src/app/core/services/statistics.service';

@Component({
  selector: 'app-counter-container',
  templateUrl: './counter-container.component.html',
  styleUrls: ['./counter-container.component.css']
})
export class CounterContainerComponent implements OnInit,OnDestroy {

  notifier = new Subject<void>;
  
  constructor(private readonly statisticsService: StatisticsService) { }

  postsCount!: number;
  usersCount!:number;
  ngOnInit(): void {
    this.getUserCount();
    this.getPostCount();
  }
  getUserCount(){
    this.statisticsService.getUserCount()
    .pipe(takeUntil(this.notifier))
      .subscribe((count) => {
        this.usersCount=count;
      })
  }
  getPostCount(){
    this.statisticsService.getPostCount()
    .pipe(takeUntil(this.notifier))
      .subscribe((count) => {
        this.postsCount=count;
      })
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }

}
