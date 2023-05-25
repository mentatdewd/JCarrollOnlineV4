import { HierarchyNodesModel } from "../HierarchyNode/HierarchyNodeModel";
import { ThreadEntryModel } from "./ThreadEntryModel";

export interface ThreadEntryDetailItemsModel {
  NumberOfReplies: number;
  ForumThreadEntries: HierarchyNodesModel<ThreadEntryModel>;
}
