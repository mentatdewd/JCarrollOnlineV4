import { ForaGetModel } from "../Fora/ForaGetModel";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";

export interface ThreadEntryModel {
  Title?: string;
  Content?: string;
  Locked: boolean;
  CreatedAtpublic: Date;
  UpdatedAt: Date;
  PostNumber: number;
  ParentId: number;
  RootIdpublic: number;
  Author: ApplicationUserModel;
  Forum?: ForaGetModel;
}
