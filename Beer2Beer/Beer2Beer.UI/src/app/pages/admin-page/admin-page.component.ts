import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { AdminService } from 'src/app/core/services/admin.service';
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

  constructor(private readonly userService: UserService, private readonly adminService: AdminService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers()
    .pipe(takeUntil(this.notifier))
      .subscribe((users) => {
        this.users = users;
      })
  }

  onSearch(obj: {searchType: string, searchInput: string}){
    if(obj.searchType === 'firstName'){
      this.adminService.getUsersByFirstName(obj.searchInput)
      .pipe(takeUntil(this.notifier))
      .subscribe((users) => {
        this.users = users;
      })
    }
    else if(obj.searchType === 'userName'){
      this.adminService.getUsersByUserName(obj.searchInput)
      .pipe(takeUntil(this.notifier))
      .subscribe((users) => {
        this.users = users;
      })
      console.log(this.users);
    }
    else if(obj.searchType === 'email'){
      this.adminService.getUsersByEmail(obj.searchInput)
      .pipe(takeUntil(this.notifier))
      .subscribe((users) => {
        this.users = users;
      })
    }
  }

  resetUsers()
  {
    this.users.length = 0;
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
