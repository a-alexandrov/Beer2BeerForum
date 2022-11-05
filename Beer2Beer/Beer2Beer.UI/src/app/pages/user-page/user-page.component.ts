import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit, OnDestroy{
  notifier = new Subject<void>;
  userId!: any;
  user!: User;

  constructor(
    private activatedRoute : ActivatedRoute,
    private readonly userService: UserService,
    ) { }

  ngOnInit(): void {
    this.userId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getUser()
  }

  getUser(){
    this.userService
      .getUserById(parseInt(this.userId))
      .pipe(takeUntil(this.notifier))
      .subscribe((currentUser) => this.user = currentUser)
  }
  
  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
