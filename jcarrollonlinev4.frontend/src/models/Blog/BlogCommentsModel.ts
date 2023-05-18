import { BlogFeedModelBase } from "./BlogFeedModelBase";

export interface BlogCommentsModel extends BlogFeedModelBase {
  BlogItemId: number;
  BlogComments: string[];
}
