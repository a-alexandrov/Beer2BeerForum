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

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PostComponent,
    PostPageComponent,
    BirichkoComponent,
    HeaderComponent,
    CounterComponent,
    CounterContainerComponent,
    ButtonContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
