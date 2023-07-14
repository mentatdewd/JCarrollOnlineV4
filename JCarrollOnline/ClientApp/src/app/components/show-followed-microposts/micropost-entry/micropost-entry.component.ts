import { Component, Input } from '@angular/core';
import { MicroPostFeedItem } from '../../../models/micropost-feed-item.model';

@Component({
  selector: 'app-micropost-entry',
  templateUrl: './micropost-entry.component.html',
  styleUrls: ['./micropost-entry.component.scss']
})
export class MicropostEntryComponent {
  @Input('post') post: MicroPostFeedItem;
}
