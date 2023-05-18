import { IModelBase } from "../IModelBase";

export interface ManageSetPasswordModel extends IModelBase {
  NewPassword: string;
  ConfirmPassword: string;
}
