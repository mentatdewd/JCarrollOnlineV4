import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface AdminThreadEntriesCreateModel extends ThreadEntriesModelBase {
  ParentPostNumber: number;
  ParentId: number;
  RootId: number;
  ForumId: number;
  Title?: string;
  Content?: string;
  Author?: ApplicationUserModel;
}
