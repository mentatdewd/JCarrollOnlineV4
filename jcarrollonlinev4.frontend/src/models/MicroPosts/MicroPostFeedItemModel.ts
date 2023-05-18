import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostFeedItemModel extends MicropostModelBase {
  Author?: ApplicationUserModel;
  Content?: string;
  CreatedAt: Date;
  TimeAgo?: string;
}
