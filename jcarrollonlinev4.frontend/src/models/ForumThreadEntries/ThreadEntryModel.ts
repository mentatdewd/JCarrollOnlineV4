import { IModelBase } from "../IModelBase";
import { ApplicationUserModel } from "../Users/ApplicationUserModel";

export interface ThreadEntryModel extends IModelBase {
  Title?: string;
  Content?: string;
  Locked: boolean;
  CreatedAtpublic: Date;
  UpdatedAt: Date;
  PostNumber: number;
  ParentId: number;
  RootIdpublic: number;
  Author: ApplicationUserModel;
  Forum?: ForaModel;
}
