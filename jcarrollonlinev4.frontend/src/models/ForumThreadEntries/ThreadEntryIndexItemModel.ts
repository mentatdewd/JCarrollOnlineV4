import { ForaModel } from "../Fora/ForaModel";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";

export interface ThreadEntryIndexItemModel extends ThreadEntriesModelBase {
  Forum: ForaModel;
  Replies: number;
  LastReply: Date;
  Recs: number;
  Views: number;
  Author: ApplicationUserModel;
  Title: string;
  CreatedAt: Date;
}
