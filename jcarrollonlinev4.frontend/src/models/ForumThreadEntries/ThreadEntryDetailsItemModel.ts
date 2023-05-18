import { ForaModel } from "../Fora/ForaModel";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface ThreadEntryDetailsItemModel extends ThreadEntriesModelBase {
  ParentId: number;
  RootId: number;
  ParentPostNumber: number;
  Forum?: ForaModel;
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
