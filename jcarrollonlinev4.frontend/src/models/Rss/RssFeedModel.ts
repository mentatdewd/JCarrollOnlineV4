import { RssFeedItemModel } from "./RssFeedItemModel";
import { RssFeedModelBase } from "./RssFeedModelBase";

export interface RssFeedModel extends RssFeedModelBase {
  RssFeedItems: RssFeedItemModel[];
}
