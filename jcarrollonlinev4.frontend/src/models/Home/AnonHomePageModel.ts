import { BlogFeedModel } from "../Blog/BlogFeedModel";
import { IModelBase } from "../IModelBase";

export interface AnonHomepageModelBase extends IModelBase {
}

export interface AnonHomepageModel extends AnonHomepageModelBase {
  BlogFeed: BlogFeedModel;
}
