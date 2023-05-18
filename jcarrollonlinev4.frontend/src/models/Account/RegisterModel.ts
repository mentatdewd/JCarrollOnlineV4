import { IModelBase } from "../IModelBase";

export interface RegisterModel extends IModelBase {
  UserName?: string;
  Email?: string;
  Password?: string;
  ConfirmPassword?: string;
}
