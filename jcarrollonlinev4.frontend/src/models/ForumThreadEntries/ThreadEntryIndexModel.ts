import { ForaGetModel } from "../Fora/ForaGetModel";
import { ThreadEntryIndexItemModel } from "./ThreadEntryIndexItemModel";

export interface ThreadEntryIndexModel {
  ThreadEntryIndex: ThreadEntryIndexItemModel[];

  Forum: ForaGetModel;
  Title: string;
  Content: string;
}
