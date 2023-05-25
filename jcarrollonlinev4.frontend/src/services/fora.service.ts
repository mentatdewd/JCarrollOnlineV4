import { Injectable } from '@angular/core';
import { ForaPostModel } from '../models/Fora/ForaPostModel';

import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
  HttpResponse,
} from '@angular/common/http';
import { catchError, mergeMap, Observable, throwError } from 'rxjs';
import { ForaGetModel } from '../models/Fora/ForaGetModel';

@Injectable({
  providedIn: 'root',
})

export class ForaService {
  apiUrl: string = 'https://localhost:7071/api/Fora/';
  headers = new HttpHeaders().set('Content-Type', 'application/json').set('charset', 'utf-8');

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
  create(model: ForaPostModel): Observable<ForaPostModel> {
    return this.http.post<ForaPostModel>(`${this.apiUrl}` + 'CreateForum', model, { headers: this.headers }).pipe(
      catchError(e => this.handleError(e))
    );
  }

  // Get
  get(): Observable<ForaGetModel[]> {
    return this.http.get<ForaGetModel[]>(`${this.apiUrl}` + 'GetFora', { headers: this.headers });
  };
}
