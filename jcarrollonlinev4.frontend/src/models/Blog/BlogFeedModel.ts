import { BlogFeedItemModel } from "./BlogFeedItemModel";
import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogFeedModel extends BlogFeedModelBase {
  BlogFeedItemModels?: BlogFeedItemModel[];
}
