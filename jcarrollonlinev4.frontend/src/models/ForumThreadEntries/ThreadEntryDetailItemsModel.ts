export interface ThreadEntryDetailItemsModel extends ThreadEntriesModelBase {
  NumberOfReplies: number;
  ForumThreadEntries: HierarchyNodesModel[ThreadEntryDetailsItemModel]
}
