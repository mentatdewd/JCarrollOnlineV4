import { BlogFeedModel } from "../Blog/BlogFeedModel";

export interface AnonHomepageModelBase {
}

export interface AnonHomepageModel extends AnonHomepageModelBase {
  BlogFeed: BlogFeedModel;
}
