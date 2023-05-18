import { UserItemModel } from "./UserItemModel";
import { UserModelBase } from "./UserModelBase";

export interface UsersIndexModel extends UserModelBase {
  Users: UserItemModel[];
  //public ICollection<UserItemModel> Users { get; set; }
}
