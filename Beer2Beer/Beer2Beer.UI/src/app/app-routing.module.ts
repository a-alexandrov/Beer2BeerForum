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

const routes: Routes = [
  {
    path: '', component: HomePageComponent
  },
  {
    path: 'post', component: PostPageComponent
  },
  {
    path: 'birichko', component: BirichkoComponent
  },
  {
    path: 'header', component: HeaderComponent
  },
  {
    path: 'counter-container', component: CounterContainerComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  },
  {
    path: 'user/:id', component: UserPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
