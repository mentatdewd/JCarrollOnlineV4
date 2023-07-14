import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, Subject, throwError } from 'rxjs';
import { AuthService } from './auth.service';
import { MicroPostFeedItem } from '../models/micropost-feed-item.model';

@Injectable({
  providedIn: 'root'
})

export class MicropostService {

  apiUrl: string = 'https://localhost:44450/api/Micropost/';
  private subjectName = new Subject<any>();

  headers = new HttpHeaders({
    Authorization: `Bearer ${this.authService.accessToken}`,
    'Content-Type': 'application/json',
    Accept: 'application/json, text/plain, */*'
  });

  constructor(private http: HttpClient, private authService: AuthService) { }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  // Post
  createMicropost(content: string): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}` + 'CreateMicropost', '"' + content + '"', { headers: this.headers }).pipe(
      catchError(e => this.handleError(e))
    );
  }

  getFollowedMicroposts(): Observable<MicroPostFeedItem[]> {
    return this.http.get<MicroPostFeedItem[]>(`${this.apiUrl}` + 'GetFollowedMicroposts', { headers: this.headers }).pipe(
      catchError(e => this.handleError(e))
    );
  }

  sendUpdate(message: string) {
    this.subjectName.next({ text: message });
  }

  getUpdate(): Observable<any> {
    return this.subjectName.asObservable();
  }
}
