import { BlogFeedModel } from "./BlogFeedModel";
import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogIndexModel extends BlogFeedModelBase {
  BlogFeedItems?: BlogFeedModel;
}
