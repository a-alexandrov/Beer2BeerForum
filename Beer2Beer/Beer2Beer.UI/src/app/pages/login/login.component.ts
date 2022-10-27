import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/shared/models/user.model';
import { UserLogin } from 'src/app/shared/models/userlogin.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide=true;
  profileForm = new FormGroup({
    email: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
  });

  constructor(private auth:AuthenticationService) { }

  ngOnInit(){
  }
  submit(){
    var login:UserLogin={
      email:this.profileForm.value.email??"",
      password:this.profileForm.value.password??""
    }

    this.auth.login(login);
  }

}
