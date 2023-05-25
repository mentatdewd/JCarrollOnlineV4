import { UserFollowersModel } from "./UserFollowersModels";
import { UserFollowingModel } from "./UserFollowingModel";
import { UserModelBase } from "./UserModelBase";

export interface UserStatsModel extends UserModelBase {
  UserFollowersModel?: UserFollowersModel;
  UserFollowingModel?: UserFollowingModel;
}
