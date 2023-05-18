import { UserItemModel } from "./UserItemModel";
import { UserModelBase } from "./UserModelBase";

export interface UserFollowingModel extends UserModelBase {
  UserFollowingModel: UserItemModel[];
  Users: UserItemModel[];
}
}
