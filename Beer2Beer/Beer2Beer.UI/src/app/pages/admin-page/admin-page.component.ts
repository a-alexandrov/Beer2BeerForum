import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit, OnDestroy {
  notifier = new Subject<void>;
  users!: User[]

  constructor(private readonly userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers()
    .pipe(takeUntil(this.notifier))
      .subscribe((users) => {
        this.users = users;
        console.log(users);
      })
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
