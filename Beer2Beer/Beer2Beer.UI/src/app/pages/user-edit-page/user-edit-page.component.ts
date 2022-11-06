import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/shared/models/user.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { MatDialog } from '@angular/material/dialog';
import { InputModalFormComponent } from './input-modal-form/input-modal-form.component';
import { UploadAvatarModalComponent } from './upload-avatar-modal/upload-avatar-modal.component';
import { UserUpdate } from 'src/app/shared/models/user-update.model';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-user-edit-page',
  templateUrl: './user-edit-page.component.html',
  styleUrls: ['./user-edit-page.component.css']
})

export class UserEditPageComponent implements OnInit {
  notifier = new Subject<void>;
  userId!: any;
  user!: User;
  newUserParam: UserUpdate = new UserUpdate;
  messageName: string = 'Name must be between 4 and 32 symbols.';
  minNameLength: number = 4;
  maxNameLength: number = 32;
  url!: any;
  file!: File;

  constructor(
    private activatedRoute : ActivatedRoute,
    private readonly userService: UserService,
    public readonly imageService: Imageservice,
    private dialog: MatDialog,
    private auth: AuthenticationService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.userId = this.activatedRoute.snapshot.paramMap.get('id');
    if (parseInt(this.userId) != this.auth.getID()) {
      this.router.navigate([''])
    }
    this.getUser();
  }


  getUser(){
    this.userService
      .getUserById(parseInt(this.userId))
      .pipe(takeUntil(this.notifier))
      .subscribe((currentUser) => this.user = currentUser);
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
      if(result !== undefined)
      {
        this.user.firstName = result;
        this.newUserParam.firstName = result;
      }
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
      if(result !== undefined)
      {
        this.user.lastName = result;
        this.newUserParam.lastName = result;
      }
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
      if(result !== undefined)
      {
        this.newUserParam.passwordHash = result;
      }
    });
  }

  changeAvatarDialog(): void {
    let dialogRef = this.dialog.open(UploadAvatarModalComponent, {
      width: '400px',
      data: {
        sizeMessage: "Size limit: 1Mb.",
        filesMessage: "Accepted formats: bmp, jpg, jpeg, png, gif",
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.url = result.url;
      this.file = result.file;
    });
  }

  changePhoneDialog(){
    let dialogRef = this.dialog.open(InputModalFormComponent, {
      width: '350px',
      data: { 
        message: "Type in new phone number",
         minValue: 1,
         maxValue: 15,
         currentValue: '',
         isPassword: false
        }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined)
      {
        this.user.phoneNumber = result;
        this.newUserParam.phoneNumber = result;
      }
    });
  }

  onSaveChanges(){

     if(this.newUserParam.firstName !== null 
     || this.newUserParam.lastName !== null 
     || this.newUserParam.passwordHash !== null
     || this.newUserParam.phoneNumber !== null)
     {    
        this.newUserParam.currentUserId = this.auth.getID();
        this.newUserParam.id = this.user.id;
        this.userService.updateUser(this.newUserParam)
        .pipe(takeUntil(this.notifier))
        .subscribe((currentUser) => this.user = currentUser);
     }

     if(this.url !== undefined)
     {
        this.userService.updateUserAvatar(this.file, this.user.id)
        .pipe(takeUntil(this.notifier))
        .subscribe((currentUser) => this.user = currentUser);
     }

  }
}
