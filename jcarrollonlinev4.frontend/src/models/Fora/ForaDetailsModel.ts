import { ForumModeratorsModel } from "../ForumModerators/ForumModeratorsViewModel";
import { ThreadEntryModel } from "../ForumThreadEntries/ThreadEntryModel";
import { ForaModelBase } from "./ForaModelBase";

export interface ForaDetailsModel extends ForaModelBase {
  Title?: string;
  Description?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  ForumThreadEntries?: ThreadEntryModel[];
  ForumModerators?: ForumModeratorsModel[];
}
