import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

//import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'jcol-navbar',
  templateUrl: './jcol-navbar.component.html',
  styleUrls: ['./jcol-navbar.component.scss']
})

export class JcolNavbarComponent implements OnInit {
  public isUserLoggedIn: boolean;
  public markNotificationsAsRead: true;
  public notificationsTitle: "";
  public userName: "";
  newNotificationCount: 1;

  constructor(public router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
      this.isUserLoggedIn = isLoggedIn;
    });
  }
}
