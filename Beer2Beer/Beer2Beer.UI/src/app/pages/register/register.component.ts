import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { UserRegister } from 'src/app/shared/models/user-register.model';
import { RegisterService } from 'src/app/core/services/register.service';
import { catchError, Subject, takeUntil, throwError } from 'rxjs';
import { User } from 'src/app/shared/models/user.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  notifier = new Subject<void>;
  success?: boolean;
  message?: string;
  user?: User;

  hide=true;
  registerForm = new FormGroup({
    firstname: new FormControl('',Validators.required),
    lastname: new FormControl('',Validators.required),
    email: new FormControl('',Validators.required,),
    username: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
  });
  
  constructor(private registerService:RegisterService, public router: Router) { }

  ngOnInit(): void {
  }

  async submit(){
    var user:UserRegister={
      firstname:this.registerForm.value.firstname??"",
      lastname:this.registerForm.value.lastname??"",
      email:this.registerForm.value.email??"",
      username:this.registerForm.value.username??"",
      password:this.registerForm.value.password??""
    }

    this.success = true;
    this.registerService.post(user)
    .pipe(takeUntil(this.notifier))
     .pipe(catchError(err => {
       this.message = err.error;
       this.success = false;
       return err.error;
   }))
    .subscribe((user) => {
      let usr = user as User;

      if(this.success)
      {
        alert(`Welcome, ${usr.username} to the forum!`);
        this.router.navigate(['login']);
      }
    });
  }

  ngOnDestroy(): void {
    this.notifier.next();
    this.notifier.complete();
  }

  onClickFailRegister(){
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['register']);
    });
  }


}
