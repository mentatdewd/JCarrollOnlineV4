import { NgModule, Injectable } from '@angular/core';
import { RouterModule, ExtraOptions, Routes, DefaultUrlSerializer, UrlSerializer, UrlTree } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SettingsComponent } from './components/settings/settings.component';
import { AboutComponent } from './components/about/about.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { Utilities } from './services/utilities';
import { ForaComponent } from './components/fora/fora.component';
import { CreateForumComponent } from './components/fora/create-forum/create-forum.component';
import { ThreadsComponent } from './components/fora/threads/threads.component';
import { ThreadCreateComponent } from './components/fora/threads/thread-create/thread-create.component';
import { ThreadComponent } from './components/fora/threads/thread/thread.component';
import { ThreadReplyComponent } from './components/fora/threads/thread/thread-reply/thread-reply.component';


@Injectable()
export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  parse(url: string): UrlTree {
    const possibleSeparators = /[?;#]/;
    const indexOfSeparator = url.search(possibleSeparators);
    let processedUrl: string;

    if (indexOfSeparator > -1) {
      const separator = url.charAt(indexOfSeparator);
      const urlParts = Utilities.splitInTwo(url, separator);
      urlParts.firstPart = urlParts.firstPart.toLowerCase();

      processedUrl = urlParts.firstPart + separator + urlParts.secondPart;
    } else {
      processedUrl = url.toLowerCase();
    }

    return super.parse(processedUrl);
  }
}


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard], data: { title: 'Home' } },
  { path: 'login', component: LoginComponent, data: { title: 'Login' } },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard], data: { title: 'Settings' } },
  { path: 'about', component: AboutComponent, data: { title: 'About Us' } },
  { path: 'home', redirectTo: '/', pathMatch: 'full' },
  { path: 'fora', component: ForaComponent, data: { title: 'Fora' } },
  { path: 'fora/create-forum', component: CreateForumComponent, canActivate: [AuthGuard], data: { title: 'Create Forum' } },
  { path: 'fora/threads', component: ThreadsComponent, canActivate: [AuthGuard], data: { title: 'Forum Threads' } },
  { path: 'fora/threads/thread-create', component: ThreadCreateComponent, canActivate: [AuthGuard], data: { title: 'Create Thread' } },
  { path: 'fora/threads/thread', component: ThreadComponent, canActivate: [AuthGuard], data: { title: 'Thread' } },
  { path: 'fora/threads/thread/thread-reply', component: ThreadReplyComponent, canActivate: [AuthGuard], data: { title: 'Thread Reply' } },
  { path: '**', component: NotFoundComponent, data: { title: 'Page Not Found' } }
];


export const routingConfiguration: ExtraOptions = {
  paramsInheritanceStrategy: 'always'
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routingConfiguration)],
  exports: [RouterModule],
  providers: [
    AuthService,
    AuthGuard,
    { provide: UrlSerializer, useClass: LowerCaseUrlSerializer }]
})
export class AppRoutingModule { }
