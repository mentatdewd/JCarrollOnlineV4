import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogCommentItemModel extends BlogFeedModelBase {
  Id: number;
  Author?: string;
  Content?: string;
  BlogItemId: number;
  CreatedAt: Date;
  TimeAgo?: string;
  ReturnUrl: URL;
}
