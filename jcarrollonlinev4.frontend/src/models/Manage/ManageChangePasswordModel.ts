import { IModelBase } from "../IModelBase";

export interface ManageChangePasswordModel extends IModelBase {
  OldPassword: string;
  NewPassword: string;
  ConfirmPassword: string;
}
