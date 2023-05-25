import { ForaGetModel } from "../Fora/ForaGetModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";
import { ThreadEntryDetailItemsModel } from "./ThreadEntryDetailItemsModel";

    export interface ThreadEntryDetailsModel extends ThreadEntriesModelBase
    {
      ForumThreadEntryDetailItems: ThreadEntryDetailItemsModel;

      ForaDetailsModel: ForaGetModel;
      Replies: number;
    }
