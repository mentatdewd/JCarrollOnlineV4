import { ForaModelBase } from "./ForaModelBase";
import { LastThreadModel } from "./LastThreadModel";

export interface ForaIndexItemModel extends ForaModelBase {
  Title?: string;
  Description?: string;
  ThreadCount: number;
  LastThread?: LastThreadModel;
}
