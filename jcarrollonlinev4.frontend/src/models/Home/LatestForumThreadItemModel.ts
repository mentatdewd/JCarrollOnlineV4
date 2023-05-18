import { IModelBase } from "../IModelBase";

export interface LatestForumThreadItemModel extends IModelBase {
  ForumTitle: string;
  ThreadTitle: string;
  ForumId: number;
  ThreadId: number;
}
