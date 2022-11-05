import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { AdminService } from 'src/app/core/services/admin.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-admin-controls',
  templateUrl: './admin-controls.component.html',
  styleUrls: ['./admin-controls.component.css']
})
export class AdminControlsComponent implements OnInit, OnDestroy {
  @Input() user!: User;
  notifier = new Subject<void>;
  constructor(private readonly adminService: AdminService) { }

  ngOnInit(): void {
  }

  onToggleUserBlocking() {
    this.user.isBlocked = !this.user.isBlocked;

    if (this.user.isBlocked){
      this.adminService.blockUserByUserName(this.user.username)
        .pipe(takeUntil(this.notifier))
        .subscribe((user) => {
          this.user = user;
        });
    }
    else {
      this.adminService.unblockUserByUserName(this.user.username)
        .pipe(takeUntil(this.notifier))
        .subscribe((user) => {
          this.user = user;
        });
    }
  }

  onToggleUserAdmin() {
    this.user.isAdmin = !this.user.isAdmin;

    if (this.user.isAdmin){
      this.adminService.promoteUserByUserName(this.user.username)
        .pipe(takeUntil(this.notifier))
        .subscribe((user) => {
          this.user = user;
        });
    }
    else {
      this.adminService.demoteUserByUserName(this.user.username)
        .pipe(takeUntil(this.notifier))
        .subscribe((user) => {
          this.user = user;
        });
    }
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }
}
