import { Injectable } from '@angular/core';
import { ForaCreateModel } from '../models/Fora/ForaCreateModel';

import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class ForaService {
  apiUrl: string = 'https://localhost:7071/api/Fora/CreateForum';
  headers = new HttpHeaders().set('Content-Type', 'application/json').set('charset','utf-8');

  constructor(private http: HttpClient) { }

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
  create(model: ForaCreateModel): Observable<ForaCreateModel> {
    return this.http.post<ForaCreateModel>(`${this.apiUrl}`, model, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e))
    );
  }
}
