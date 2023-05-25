import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, FormBuilder, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { JcolNavbarComponent } from './jcol-navbar/jcol-navbar.component';
import { HomePageComponent } from './home-page/home-page.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { BackgroundComponent } from './welcome-page/background/background.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserStatsComponent } from './user-stats/user-stats.component';
import { MicroPostFormComponent } from './micro-post-form/micro-post-form.component';
import { LatestForumThreadsComponent } from './latest-forum-threads/latest-forum-threads.component';
import { MicroPostFeedComponent } from './micro-post-feed/micro-post-feed.component';
import { RssFeedComponent } from './rss-feed/rss-feed.component';
import { BlogFeedComponent } from './blog-feed/blog-feed.component';
import { GravatarDirective } from '../directives/gravatar.directive';

import { UserInfoService } from '../services/userinfo.service';
import { ForaService } from '../services/fora.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UsersComponent } from './users/users.component';
import { ForaComponent } from './fora/fora.component';
import { ProfileComponent } from './profile/profile.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { SandboxComponent } from './sandbox/sandbox.component';
import { YellowstoneSlideshowComponent } from './yellowstone-slideshow/yellowstone-slideshow.component';
import { CreateComponent } from './fora/create/create.component';

@NgModule({
  declarations: [
    AppComponent,
    JcolNavbarComponent,
    HomePageComponent,
    WelcomePageComponent,
    BackgroundComponent,
    UserInfoComponent,
    UserStatsComponent,
    MicroPostFormComponent,
    LatestForumThreadsComponent,
    MicroPostFeedComponent,
    RssFeedComponent,
    BlogFeedComponent,
    GravatarDirective,
    LoginComponent,
    RegisterComponent,
    UsersComponent,
    ForaComponent,
    ProfileComponent,
    AboutComponent,
    ContactComponent,
    SandboxComponent,
    YellowstoneSlideshowComponent,
    CreateComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: WelcomePageComponent },
      { path: 'Home', component: HomePageComponent },
      { path: 'Welcome', component: WelcomePageComponent },
      { path: 'Register', component: RegisterComponent },
      { path: 'Login', component: LoginComponent },
      { path: 'Users', component: UsersComponent },
      { path: 'Fora', component: ForaComponent },
      { path: 'Fora/Create', component: CreateComponent },
      { path: 'Profile', component: ProfileComponent },
      { path: 'About', component: AboutComponent },
      { path: 'Contact', component: ContactComponent },
      { path: 'Sandbox', component: SandboxComponent },
      { path: 'Yellowstone', component: YellowstoneSlideshowComponent },
    ]),
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [UserInfoService, ForaService, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
