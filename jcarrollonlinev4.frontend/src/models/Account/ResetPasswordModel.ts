import { IModelBase } from "../IModelBase";

export interface ResetPasswordModel extends IModelBase {
  Email?: string;
  Password?: string;
  ConfirmPassword?: string;
  Code?: string;
}
