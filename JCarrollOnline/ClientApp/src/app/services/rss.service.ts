import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RSSSevice {

  apiUrl: string = 'https://localhost:44450/api/RSS/';

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

  theMariners(): Observable<any> {
    let url = this.apiUrl + "theMariners";
    return this.http.get(url, { responseType: 'text' });
  }
}
