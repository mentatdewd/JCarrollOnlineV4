import { Component, Input } from "@angular/core";
import * as xml2js from "xml2js";
import { ItemModel, RSSModel } from '../../models/RSSFeedModel';
import { RSSService } from '../../services/rss.service';

@Component({
  selector: 'app-rss-feed',
  templateUrl: './rss-feed.component.html',
  styleUrls: ['./rss-feed.component.scss']
})

//under class
export class RssFeedComponent {

  constructor(private rssService: RSSService) { }
  ngOnInit(): void {
    this.GetRssFeedData()
  }

  theMarinersRssData: RSSModel = new RSSModel();
  isFeedDataArrived = false;

  GetRssFeedData() {
    this.rssService.theMariners().subscribe(
      data => {
        console.log(data);
        let parseString = xml2js.parseString;
        parseString(data, (err, result: RSSModel): void => {
          this.theMarinersRssData = result;
          this.isFeedDataArrived = true;
        }
        )
      });
  }
}
