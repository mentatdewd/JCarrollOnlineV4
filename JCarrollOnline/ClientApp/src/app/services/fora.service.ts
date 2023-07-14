import { Injectable } from '@angular/core';
import { ForumModel } from '../models/Fora/forum.model';
import { ThreadModel } from '../models/threads/ThreadModel';
import { AlertService } from '../services/alert.service';

import {
    HttpClient,
    HttpErrorResponse,
    HttpHeaders
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { ForaModel } from '../models/Fora/fora.model';
import { ThreadEntryNode } from '../models/Threads/ThreadEntryNode.Model';
import { ThreadsModel } from '../models/Threads/ThreadsModel';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})

export class ForaService {
  apiUrl: string = 'https://localhost:44450/api/Fora/';

  headers = new HttpHeaders({
    Authorization: `Bearer ${this.authService.accessToken}`,
    'Content-Type': 'application/json',
    Accept: 'application/json, text/plain, */*'
  });

  constructor(private http: HttpClient,
    private authService: AuthService,
    private alertService: AlertService) { }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
      this.log('An error occurred:' + error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
      this.log(`Backend returned code ${error.status}, body was: `+ error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  // Post
  createForum(model: ForumModel): Observable<ForumModel> {
    const url = `${this.apiUrl}` + 'CreateForum';
    return this.http.post<ForumModel>(url, model, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e))
    );
  }

  //TODO: renamed this to getFora, to keep in line with naming convention
  // Get
  getAllFora(): Observable<ForaModel[]> {
    const url = `${this.apiUrl}` + 'GetAllFora';
    return this.http.get<ForaModel[]>(url,
      { headers: this.headers }).pipe(
        catchError(e => this.handleError(e)));;
  };

  // Get
  getForum(id: number): Observable<ForumModel> {
    const url = `${this.apiUrl}GetForum/${id}`;
    return this.http.get<ForumModel>(url, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e)));
  }

  // Get
  getForumThreads(forumId: number): Observable<ThreadsModel[]> {
    const url = `${this.apiUrl}` + 'GetForumThreads?forumid=' + forumId;
    return this.http.get<ThreadsModel[]>(url, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e)));
  }

  getThread(rootId: number): Observable<ThreadEntryNode[]> {
    const url = `${this.apiUrl}` + 'GetForumThread?rootId=' + rootId;
    return this.http.get<ThreadEntryNode[]>(url, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e)));
  }

  getForumThreadEntry(threadEntryId: number): Observable<ThreadEntryNode> {
    const url = `${this.apiUrl}` + 'GetForumThreadEntry?rootId=' + threadEntryId;
    return this.http.get<ThreadEntryNode>(url, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e)));
  }

  // Post
  threadCreate(model: ThreadModel): Observable<ThreadModel> {
    const url = `${this.apiUrl}` + 'ThreadCreate';
    return this.http.post<ThreadModel>(url, model,
      { headers: this.headers }).pipe(
        catchError(e => this.handleError(e))
      );
  }

  threadReply(threadReply: ThreadEntryNode) {
    const url = `${this.apiUrl}` + 'ThreadReply';
    return this.http.post<ThreadEntryNode>(url, threadReply,
      { headers: this.headers }).pipe(
      catchError(e => this.handleError(e)));
  }

  /** Log a ForaService message with the MessageService */
  private log(message: string) {
    this.alertService.logError(message);
  }
}
