import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserLogin } from 'src/app/shared/models/user-login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide=true;
  loginForm = new FormGroup({
    email: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
  });

  constructor(private auth:AuthenticationService) { }

  ngOnInit(){
  }
  submit(){
    var login:UserLogin={
      email:this.loginForm.value.email??"",
      password:this.loginForm.value.password??""
    }

    this.auth.login(login);
  }

}
