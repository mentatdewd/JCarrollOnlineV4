import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Init } from 'v8';
import { MicroPostFeedItem } from '../../models/micropost-feed-item.model';
import { MicropostService } from '../../services/micropost.service';

@Component({
  selector: 'app-show-followed-microposts',
  templateUrl: './show-followed-microposts.component.html',
  styleUrls: ['./show-followed-microposts.component.scss']
})
export class ShowFollowedMicropostsComponent implements OnInit, OnDestroy {
  public posts: MicroPostFeedItem[];
  public post0: MicroPostFeedItem;

  messageReceived: any;
  private subscriptionName: Subscription; //important to create a subscription

  constructor(private micropostService: MicropostService) {
  }

  ngOnInit() {
    this.micropostService.getFollowedMicroposts().subscribe({
      next: data => {
        console.log(data);
        //this.router..
        this.posts = data;
        this.post0 = this.posts.at(0);
      },
      error: error => {
        console.log(error);
      }
    });

    this.subscriptionName = this.micropostService.getUpdate().subscribe
      (message => { //message contains the data sent from service
        this.messageReceived = message
        this.micropostService.getFollowedMicroposts().subscribe({
          next: data => {
            console.log(data);
            //this.router..
            this.posts = data;
            this.post0 = this.posts.at(0);
          },
          error: error => {
            console.log(error);
          }
        });
      });
  }

  ngOnDestroy() { this.subscriptionName.unsubscribe(); }
}
