import { UserModelBase } from "./UserModelBase";

    export interface UserStatsModel extends UserModelBase
    {
      UserFollowersModel?: UserFollowers;
      UserFollowingModel?: UsersFollowing;
    }
