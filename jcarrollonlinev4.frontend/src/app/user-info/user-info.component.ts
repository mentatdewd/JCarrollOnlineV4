import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatFormField } from '@angular/material/form-field';
import { MatCard } from '@angular/material/card';
import { UserInfoService } from '../userinfo.service';
import { UserInfoModel } from '../../models/user-info';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent {
  public username?: string;
  public mat_card?: MatCard;
  public form_field?: MatFormField;
  public email?: string;
  public userinfo?: UserInfoModel;

  constructor(http: HttpClient, private userInfoService: UserInfoService, ) {
    this.userInfoService.getUserInfo().subscribe({
      next: (response) => {
        console.log(response);
        this.userinfo = response;
      },
      error: (error) => { console.error(error); },    // errorHandler }
    });
  }
}
