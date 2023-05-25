import { ForumModeratorsModel } from "../ForumModerators/ForumModeratorsViewModel";
import { ThreadEntryModel } from "../ForumThreadEntries/ThreadEntryModel";

export interface ForaDetailsModel {
  Title?: string;
  Description?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  ForumThreadEntries?: ThreadEntryModel[];
  ForumModerators?: ForumModeratorsModel[];
}
