import { Component, Input, OnInit } from '@angular/core';
import { ItemModel } from '../../../models/RSSFeedModel';

@Component({
  selector: 'app-rss-feed-item',
  templateUrl: './rss-feed-item.component.html',
  styleUrls: ['./rss-feed-item.component.scss']
})
export class RssFeedItemComponent implements OnInit {
  @Input() rssEntry: ItemModel;

  isThreadDataArrived: boolean = true;
  private testrssEntry: ItemModel;

  constructor() {
    console.log("working");
  }

  ngOnInit() {
    console.log("working");
    this.testrssEntry = this.rssEntry;
  }
}
