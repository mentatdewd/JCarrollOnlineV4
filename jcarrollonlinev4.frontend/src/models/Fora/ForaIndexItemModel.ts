import { LastThreadModel } from "./LastThreadModel";

export interface ForaIndexItemModel {
  Title?: string;
  Description?: string;
  ThreadCount: number;
  LastThread?: LastThreadModel;
}
