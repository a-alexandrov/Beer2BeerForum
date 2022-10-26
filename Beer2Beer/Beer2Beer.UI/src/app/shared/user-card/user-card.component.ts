import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import {User} from '../models/user.model'

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit, OnDestroy{

  user: User = new User;
  userId !: any;

  notifier = new Subject<void>;

  constructor(private activatedRoute : ActivatedRoute, private readonly userService: UserService){

  }

  ngOnInit(): void {
    this.userId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getUser()
  }

  getUser(){
    this.userService.getUserById(parseInt(this.userId)).pipe(takeUntil(this.notifier)).subscribe((currentUser) => this.user = currentUser)
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }

}
