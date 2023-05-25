import { ForaGetModel } from "../Fora/ForaGetModel";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface ThreadEntryDetailsItemModel extends ThreadEntriesModelBase {
  ParentId: number;
  RootId: number;
  ParentPostNumber: number;
  Forum?: ForaGetModel;
  ParentAuthor?: string;
  PostCount: number;
  Author?: ApplicationUserModel;
  Content?: string;
  Title?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  PostNumber: number;
  Locked: boolean;
}
