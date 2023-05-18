import { MicropostFeedItemModel } from "../MicroPosts/MicroPostFeedItemModel";
import { UserModelBase } from "./UserModelBase";

export interface UserItemModel extends UserModelBase {
  UserId?: string;
  MicropostEmailNotifications: boolean;
  MicropostSmsNotifications: boolean;
  MicropostsAuthored: number;
  Microposts?: MicropostFeedItemModel[];
}
