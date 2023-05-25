import { Injectable } from '@angular/core';
import { UserInfoModel } from '../models/user-info';

import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class UserInfoService {
  apiUrl: string = 'https://localhost:7071/api/UserInfo';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient) { }

  // Read
  getUserInfo() {
    return this.http.get<UserInfoModel>(`${this.apiUrl}`);
  }
}
