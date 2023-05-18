import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface ThreadEntriesEditModel extends ThreadEntriesModelBase {
  ParentId: number;
  RootId: number;
  ForumId: number;
  PostNumber: number;
  Locked: boolean;
  CreatedAt: Date;
  Author?: ApplicationUserModel;
  Title?: string;
  Content?: string;
}
