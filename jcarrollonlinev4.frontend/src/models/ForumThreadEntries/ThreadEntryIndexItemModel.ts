import { ForaGetModel } from "../Fora/ForaGetModel";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";

export interface ThreadEntryIndexItemModel {
  Forum: ForaGetModel;
  Replies: number;
  LastReply: Date;
  Recs: number;
  Views: number;
  Author: ApplicationUserModel;
  Title: string;
  CreatedAt: Date;
}
