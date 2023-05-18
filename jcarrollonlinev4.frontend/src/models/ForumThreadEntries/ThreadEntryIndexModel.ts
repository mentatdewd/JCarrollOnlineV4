import { ForaModel } from "../Fora/ForaModel";
import { ThreadEntriesModelBase } from "./ThreadEntriesModelBase";
import { ThreadEntryIndexItemModel } from "./ThreadEntryIndexItemModel";

export interface ThreadEntryIndexModel extends ThreadEntriesModelBase {
  ThreadEntryIndex: ThreadEntryIndexItemModel[];

  Forum: ForaModel;
  Title: string;
  Content: string;
}
