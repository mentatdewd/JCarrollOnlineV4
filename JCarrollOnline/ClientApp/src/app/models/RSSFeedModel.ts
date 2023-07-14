export class RSSModel {
  feed: FeedModel = new FeedModel();
}
export class FeedModel {
  channel: ChannelModel[];
}

export class ChannelModel {
  atom: string[];
  description: string[];
  generator: string[];
  item: ItemModel[] = new Array();
  language: string[];
  lastBuildDate: Date[];
  link: string[];
  pubDate: string[];
  title: string[];
}

export class ItemModel {
  creator: string[];
  guid: string[];
  image: string[];
  link: string[];
  mlbDisplayDate: string[];
  mlbDisplayDateEpoch: string[];
  mlbTeam: string[];
  pubDate: string[];
  title: string[];
}
//export class EntryModel {
//  title: string;
//  content: ContentModel[] = new Array();
//  link: LinkModel[] = new Array();
//}
//export class ContentModel {
//  _: any;
//}
//export class LinkModel {
//  $: DollerModel[] = new Array();
//}
//export class DollerModel {
//  href: string;
//}
