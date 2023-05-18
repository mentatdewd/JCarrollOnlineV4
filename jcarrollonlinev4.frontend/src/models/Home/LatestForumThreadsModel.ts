import { IModelBase } from "../IModelBase";
import { LatestForumThreadItemModel } from "./LatestForumThreadItemModel";

export interface LatestForumThreadsModel extends IModelBase {
  LatestForumThreads: LatestForumThreadItemModel[];
}
