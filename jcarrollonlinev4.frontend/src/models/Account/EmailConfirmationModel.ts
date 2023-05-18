import { IModelBase } from "../IModelBase";

export interface EmailConfirmationModel extends IModelBase {
  Id?: string;
  UserName?: string;
  Email?: string;
}
