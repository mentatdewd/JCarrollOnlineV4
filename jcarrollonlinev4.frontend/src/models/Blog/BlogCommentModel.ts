import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogCommentModel extends BlogFeedModelBase {
  Author?: string;
  Content?: string;
  BlogItemId: number;
}
