import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { BlogCommentsModel } from "./BlogCommentsModel";
import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogFeedItemModel extends BlogFeedModelBase {
  Id: number;
  Author?: ApplicationUserModel;
  AuthorId?: string;
  Title?: string;
  Content?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  Comments?: BlogCommentsModel;
}
