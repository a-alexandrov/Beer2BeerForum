import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/shared/models/user.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { MatDialog } from '@angular/material/dialog';
import { InputModalFormComponent } from './input-modal-form/input-modal-form.component';

@Component({
  selector: 'app-user-edit-page',
  templateUrl: './user-edit-page.component.html',
  styleUrls: ['./user-edit-page.component.css']
})

export class UserEditPageComponent implements OnInit {
  notifier = new Subject<void>;
  userId!: any;
  user!: User;
  messageName: string = 'Name must be between 4 and 32 symbols.';
  minNameLength: number = 4;
  maxNameLength: number = 32;
  newPassword!: string;

  constructor(
    private activatedRoute : ActivatedRoute,
    private readonly userService: UserService,
    public readonly imageService: Imageservice,
    private dialog: MatDialog,
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

  changeFirstNameDialog(name: string): void {
    let dialogRef = this.dialog.open(InputModalFormComponent, {
      width: '350px',
      data: { 
        message: this.messageName,
         minValue: this.minNameLength,
         maxValue: this.maxNameLength,
         currentValue: name,
         isPassword: false
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.user.firstName = result;
    });
  }
  
  changeLastNameDialog(name: string): void {
    let dialogRef = this.dialog.open(InputModalFormComponent, {
      width: '350px',
      data: { 
        message: this.messageName,
         minValue: this.minNameLength,
         maxValue: this.maxNameLength,
         currentValue: name,
         isPassword: false
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.user.lastName = result;
    });
  }

  changePassDialog(): void {
    let dialogRef = this.dialog.open(InputModalFormComponent, {
      width: '350px',
      data: { 
        message: "Type in new password",
         minValue: 1,
         maxValue: 32,
         currentValue: '',
         isPassword: true
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.newPassword = result;
    });
  }

  changeAvatarDialog(): void {
    let dialogRef = this.dialog.open(InputModalFormComponent, {
      width: '350px',
      data: {
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.newPassword = result;
    });
  }
}
