import { ThreadEntryModel } from "../ForumThreadEntries/ThreadEntryModel";

export interface ForaModel {
  Id?: number;
  Title?: string;
  Description?: string;
  CreatedAt?: Date;
  UpdatedAt?: Date;
  ForumThreadEntries?: ThreadEntryModel[];
 // ForumModerators?: ForumThreadModeratorModel[];
}
