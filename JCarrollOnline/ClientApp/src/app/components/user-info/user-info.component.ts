import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { AccountService } from '../../services/account.service';
import { UserInfoService } from '../../services/user-info.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
  public userName?: string;
  public posts: number;
  public followers: number;
  public following: number;
  public mat_card?: MatCard;
  public form_field?: MatFormField;

  constructor(http: HttpClient, private userInfoService: UserInfoService, private accountService: AccountService,) {
    this.userName = accountService.currentUser.userName;
  }
}
