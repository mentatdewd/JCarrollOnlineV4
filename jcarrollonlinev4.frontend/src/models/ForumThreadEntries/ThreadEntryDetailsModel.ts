import { ForaModel } from "../Fora/ForaModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";
import { ThreadEntryDetailItemsModel } from "./ThreadEntryDetailItemsModel";

    export interface ThreadEntryDetailsModel extends ThreadEntriesModelBase
    {
      ForumThreadEntryDetailItems: ThreadEntryDetailItemsModel;

      ForaDetailsModel: ForaModel;
      Replies: number;
    }
