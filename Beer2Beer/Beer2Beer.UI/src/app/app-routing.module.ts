import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { BirichkoComponent } from './shared/birichko/birichko.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { CounterContainerComponent } from './shared/components/counter-container/counter-container.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import {UserPageComponent} from './pages/user-page/user-page.component'
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AuthorizeGuardService } from './core/services/authorize-guard.service';
import { UserEditPageComponent } from './pages/user-edit-page/user-edit-page.component';
import { PostsComponent } from './pages/posts-page/posts.component';
import { PostEditPageComponent } from './pages/post-edit-page/post-edit-page.component';

const routes: Routes = [
  {
    path: '', component: HomePageComponent
  },
  {
    path: 'post/:id', component: PostPageComponent,
    canActivate: [AuthorizeGuardService]
  },
  {
    path: 'posts', component: PostsComponent,
    canActivate: [AuthorizeGuardService]
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  },
  {
    path: 'user/:id', component: UserPageComponent
  },
  {
    path: 'admin', component: AdminPageComponent,
    canActivate: [AuthorizeGuardService]
  },
  {
    path: 'user/edit/:id', component: UserEditPageComponent,
    canActivate: [AuthorizeGuardService]
  },
  {
    path: 'post/edit/:id', component: PostEditPageComponent,
    canActivate: [AuthorizeGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
