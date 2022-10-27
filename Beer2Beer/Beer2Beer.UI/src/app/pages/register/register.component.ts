import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { UserRegister } from 'src/app/shared/models/user-register.model';
import { RegisterService } from 'src/app/core/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  hide=true;
  registerForm = new FormGroup({
    firstname: new FormControl('',Validators.required),
    lastname: new FormControl('',Validators.required),
    email: new FormControl('',Validators.required),
    username: new FormControl('',Validators.required),
    password: new FormControl('',Validators.required),
  });
  
  constructor(private registerService:RegisterService) { }

  ngOnInit(): void {
  }

  submit(){
    var user:UserRegister={
      firstname:this.registerForm.value.firstname??"",
      lastname:this.registerForm.value.lastname??"",
      email:this.registerForm.value.email??"",
      username:this.registerForm.value.username??"",
      password:this.registerForm.value.password??""
    }
    this.registerService.post(user)

  }

}
