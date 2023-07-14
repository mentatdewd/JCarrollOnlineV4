import { Injectable } from '@angular/core';
import { UserInfoModel } from '../models/user-info.model';

import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class UserInfoService {
  apiUrl: string = 'https://localhost:7071/api/users/me';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient) { }

  // Read
  getUserInfo() {
    return this.http.get<UserInfoModel>(`${this.apiUrl}`);
  }
}
