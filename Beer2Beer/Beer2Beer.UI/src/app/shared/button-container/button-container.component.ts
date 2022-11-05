import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-button-container',
  templateUrl: './button-container.component.html',
  styleUrls: ['./button-container.component.css']
})
export class ButtonContainerComponent implements OnInit {

  constructor(private auth:AuthenticationService) { }

  ngOnInit(): void {
  }

  logout(){

    this.auth.logout();

  }
  debug(){
    this.auth.showActiveUser();
  }
  
  userIsLogged(){
    return this.auth.isLogged();
  }

}
