import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { BirichkoComponent } from './shared/birichko/birichko.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { PostComponent } from './pages/post-page/post/post.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { CounterContainerComponent } from './shared/components/counter-container/counter-container.component';
import { ButtonContainerComponent } from './shared/button-container/button-container.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommentComponent } from './pages/post-page/comment/comment.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { UserPageComponent } from './pages/user-page/user-page.component';
import { RateComponent } from './shared/components/rate/rate.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialsModule } from './shared/materials/materials.module';
import { UserCardComponent } from './shared/user-card/user-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AdminControlsComponent } from './pages/admin-page/admin-controls/admin-controls.component';
import { UniversalAppInterceptor } from './core/services/universal-app-interceptor.service';
import { PostThumbnailComponent } from './shared/components/post-thumbnail/post-thumbnail.component';
import { PostListComponent } from './shared/components/post-list/post-list.component';
import { CommentThumbnailComponent } from './shared/components/comment-thumbnail/comment-thumbnail.component';
import { CommentListComponent } from './shared/components/comment-list/comment-list.component';
import { AdminSearchComponent } from './pages/admin-page/admin-search/admin-search.component';
import { UserEditPageComponent } from './pages/user-edit-page/user-edit-page.component';
import { InputModalFormComponent } from './pages/user-edit-page/input-modal-form/input-modal-form.component';
import { UploadAvatarModalComponent } from './pages/user-edit-page/upload-avatar-modal/upload-avatar-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    PostComponent,
    PostPageComponent,
    BirichkoComponent,
    HeaderComponent,
    CommentComponent,
    CounterContainerComponent,
    ButtonContainerComponent,
    LoginComponent,
    RegisterComponent,
    UserPageComponent,
    RateComponent,
    UserCardComponent,
    AdminPageComponent,
    AdminControlsComponent,
    PostListComponent,
    PostThumbnailComponent,
    CommentThumbnailComponent,
    CommentListComponent,
    AdminSearchComponent,
    UserEditPageComponent,
    InputModalFormComponent,
    UploadAvatarModalComponent,
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule, HttpClientModule, BrowserAnimationsModule, MaterialsModule,
    ReactiveFormsModule,
    FormsModule,
    JwtModule.forRoot({
    config: {
      authScheme: 'Bearer',
      headerName: 'Authorization',
      tokenGetter: () => {
        return localStorage.getItem('token');
      },
    }
  })],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: UniversalAppInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
