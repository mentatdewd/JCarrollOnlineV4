import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatDividerModule } from '@angular/material/divider';
import { TimeagoModule } from 'ngx-timeago';
import { MatTreeModule } from '@angular/material/tree';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { AngularMarkdownEditorModule } from 'angular-markdown-editor';

import { NgbModalModule, NgbTooltipModule, NgbPopoverModule, NgbDropdownModule, NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { OAuthModule } from 'angular-oauth2-oidc';
import { ToastaModule } from 'ngx-toasta';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgChartsModule } from 'ng2-charts';

import { AppRoutingModule } from './app-routing.module';
import { AppErrorHandler } from './app-error.handler';
import { AppTitleService } from './services/app-title.service';
import { AppTranslationService, TranslateLanguageLoader } from './services/app-translation.service';
import { ConfigurationService } from './services/configuration.service';
import { AlertService } from './services/alert.service';
import { ThemeManager } from './services/theme-manager';
import { LocalStoreManager } from './services/local-store-manager.service';
import { OidcHelperService } from './services/oidc-helper.service';
import { NotificationService } from './services/notification.service';
import { NotificationEndpoint } from './services/notification-endpoint.service';
import { AccountService } from './services/account.service';
import { AccountEndpoint } from './services/account-endpoint.service';

import { EqualValidator } from './directives/equal-validator.directive';
import { AutofocusDirective } from './directives/autofocus.directive';
import { BootstrapTabDirective } from './directives/bootstrap-tab.directive';
import { GroupByPipe } from './pipes/group-by.pipe';

import { AppComponent } from './components/app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SettingsComponent } from './components/settings/settings.component';
import { AboutComponent } from './components/about/about.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

import { NotificationsViewerComponent } from './components/controls/notifications-viewer.component';
import { SearchBoxComponent } from './components/controls/search-box.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { UserPreferencesComponent } from './components/controls/user-preferences.component';
import { UsersManagementComponent } from './components/controls/users-management.component';
import { RolesManagementComponent } from './components/controls/roles-management.component';
import { RoleEditorComponent } from './components/controls/role-editor.component';
import { JcolNavbarComponent } from './components/jcol-navbar/jcol-navbar.component';
import { GravatarDirective } from './directives/gravatar.directive';
import { CreateMicropostComponent } from './components/create-micropost/create-micropost.component';
import { ShowFollowedMicropostsComponent } from './components/show-followed-microposts/show-followed-microposts.component';
import { RssFeedComponent } from './components/rss-feed/rss-feed.component';
import { MicropostEntryComponent } from './components/show-followed-microposts/micropost-entry/micropost-entry.component';
import { CharacterCountDirective } from './directives/char-counter.directive';
import { ForaComponent } from './components/fora/fora.component';
import { ThreadsComponent } from './components/fora/threads/threads.component';
import { CreateForumComponent } from './components/fora/create-forum/create-forum.component';
import { ThreadCreateComponent } from './components/fora/threads/thread-create/thread-create.component';
import { ThreadComponent } from './components/fora/threads/thread/thread.component';
import { ThreadRootComponent } from './components/fora/threads/thread/thread-root/thread-root.component';
import { ThreadReplyComponent } from './components/fora/threads/thread/thread-reply/thread-reply.component';
import { ThreadEntryComponent } from './components/fora/threads/thread/thread-entry/thread-entry.component';
import { RssFeedItemComponent } from './components/rss-feed/rss-feed-item/rss-feed-item.component';
import { TemplateComponent } from './components/template/template.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    SettingsComponent,
    UsersManagementComponent, UserInfoComponent, UserPreferencesComponent,
    RolesManagementComponent, RoleEditorComponent,
    AboutComponent,
    NotFoundComponent,
    NotificationsViewerComponent,
    SearchBoxComponent,
    EqualValidator,
    AutofocusDirective,
    BootstrapTabDirective,
    GroupByPipe,
    JcolNavbarComponent,
    GravatarDirective,
    CreateMicropostComponent,
    ShowFollowedMicropostsComponent,
    RssFeedComponent,
    MicropostEntryComponent,
    CharacterCountDirective,
    ForaComponent,
    CreateForumComponent,
    ThreadCreateComponent,
    ThreadsComponent,
    ThreadComponent,
    ThreadRootComponent,
    ThreadReplyComponent,
    ThreadEntryComponent,
    RssFeedItemComponent,
    TemplateComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
    NgbTooltipModule,
    NgbPopoverModule,
    NgbDropdownModule,
    NgbCarouselModule,
    NgbModalModule,
    NgxDatatableModule,
    OAuthModule.forRoot(),
    ToastaModule.forRoot(),
    NgSelectModule,
    NgChartsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    ScrollingModule,
    MatDividerModule,
    TimeagoModule.forRoot(),
    MatTreeModule,
    MarkdownModule.forRoot({
      // loader: HttpClient, // optional, only if you use [src] attribute
      markedOptions: {
        provide: MarkedOptions,
        useValue: {
          gfm: true,
          breaks: false,
          pedantic: false,
          smartLists: true,
          smartypants: false,
        },
      },
    }),
    AngularMarkdownEditorModule.forRoot({
      // add any Global Options/Config you might want
      // to avoid passing the same options over and over in each components of your App
      iconlibrary: 'fa'
    }),
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    AlertService,
    ThemeManager,
    ConfigurationService,
    AppTitleService,
    AppTranslationService,
    NotificationService,
    NotificationEndpoint,
    AccountService,
    AccountEndpoint,
    LocalStoreManager,
    OidcHelperService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
