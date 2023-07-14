import { Component } from '@angular/core';
import { Router } from '@angular/router';

//import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'jcol-navbar',
  templateUrl: './jcol-navbar.component.html',
  styleUrls: ['./jcol-navbar.component.scss']
})

export class JcolNavbarComponent {
  public isUserLoggedIn: true;
  public canViewCustomers: true;
  public canViewProducts: true;
  public canViewOrders: true;
  public markNotificationsAsRead: true;
  public notificationsTitle: "";
  public userName: "";
  newNotificationCount: 1;

  constructor(public router: Router) { }
}
