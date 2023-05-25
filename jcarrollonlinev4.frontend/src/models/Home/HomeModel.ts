import { BlogFeedModel } from "../Blog/BlogFeedModel";
import { MicropostCreateModel } from "../MicroPosts/MicroPostCreateModel";
import { MicropostFeedModel } from "../MicroPosts/MicroPostFeedModel";
import { RssFeedModel } from "../Rss/RssFeedModel";
import { UserItemModel } from "../Users/UserItemModel";
import { UserStatsModel } from "../Users/UserStatsModel";

export interface HomeModel {
  MicropostCreateModel: MicropostCreateModel;
  MicropostFeedModel: MicropostFeedModel;
  UserStatsModel: UserStatsModel;
  UserInfoModel: UserItemModel;
  RssFeedModel: RssFeedModel;
  MicroPosts: number;
  BlogFeed: BlogFeedModel;
  //LatestForumThreadsModel: LatestForumThreadsModel;
  MicroPostPage: number;
  //OnePageOfMicroPosts: MicroPostFeedItemViewModel[];
  PageNumber: number;
}
