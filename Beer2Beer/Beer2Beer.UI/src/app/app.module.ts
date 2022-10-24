import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { BirichkoComponent } from './shared/birichko/birichko.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { PostComponent } from './pages/post-page/post/post.component';
import { HeaderComponent } from './pages/header/header.component';
import { CounterComponent } from './shared/counter/counter.component';
import { CounterContainerComponent } from './shared/counter-container/counter-container.component';
import { ButtonContainerComponent } from './shared/button-container/button-container.component';
import { HttpClientModule } from '@angular/common/http';
import { CommentComponent } from './pages/post-page/comment/comment.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PostComponent,
    PostPageComponent,
    BirichkoComponent,
    HeaderComponent,
    CounterComponent,
    CommentComponent,
    CounterContainerComponent,
    ButtonContainerComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
