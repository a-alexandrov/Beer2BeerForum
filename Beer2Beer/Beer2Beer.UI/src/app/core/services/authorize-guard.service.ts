import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuardService {

  constructor(private auth:AuthenticationService,loginService:LoginService,private router:Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<any> | Promise<any> | boolean {
      if (this.auth.getID()) {
          if (this.auth.isTokenExpired()) {
            this.auth.logout();
            this.router.navigate(['/login'])
            // Should Redirect Sig-In Page
            return false;
          } else {
            return true;
          }
      } else {
        // Should Redirect Sign-In Page
        this.auth.logout();
        this.router.navigate(['/login'])
        return false;
      }
  }
}
