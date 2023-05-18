import { ApplicationUserModel } from "./ApplicationUserModel";
import { UserModelBase } from "./UserModelBase";

export interface UserUnfollowModel extends UserModelBase {
  UserUnfollow: ApplicationUserModel;
}
