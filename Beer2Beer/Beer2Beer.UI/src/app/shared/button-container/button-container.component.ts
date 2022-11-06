import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { retry } from 'rxjs-compat/operator/retry';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-button-container',
  templateUrl: './button-container.component.html',
  styleUrls: ['./button-container.component.css']
})
export class ButtonContainerComponent implements OnInit {
  

  constructor(private auth:AuthenticationService, private readonly router:Router) { }

  ngOnInit(): void {
  }

  logout(){

    this.auth.logout();

  }
  debug(){
    this.auth.showActiveUser();
  }
  userIsAdmin(){
    return this.auth.isAdmin();
  }
  userIsLogged(){
    return this.auth.isLogged();
  }
  goToPath(path : string){
    this.router.navigate([path]);
  }
  showProfile(){
    let path = "/user/"+ this.auth.getID();
    this.goToPath(path)
  }

}
