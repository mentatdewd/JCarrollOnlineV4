import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface ThreadEntriesCreateModel extends ThreadEntriesModelBase {
  ParentPostNumber: number;
  ParentId: number;
  RootId: number;
  ForumId: number;
  Title: number;
  Content?: string;
  Author?: ApplicationUserModel;
}
