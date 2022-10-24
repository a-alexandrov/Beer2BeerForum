import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { BirichkoComponent } from './shared/birichko/birichko.component';
import { HeaderComponent } from './pages/header/header.component';
import { CounterComponent } from './shared/counter/counter.component';
import { CounterContainerComponent } from './shared/counter-container/counter-container.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
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
    path: 'counter', component: CounterComponent
  },
  {
    path: 'counter-container', component: CounterContainerComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
