import { ApplicationUserModel } from "./ApplicationUserModel";
import { UserModelBase } from "./UserModelBase";

export interface UserFollowModel extends UserModelBase {
  UserFollow?: ApplicationUserModel;
}
