import { IModelBase } from "../IModelBase";

export interface ManageVerifyPhoneNumberModel extends IModelBase {
  Code: string;
  PhoneNumber: string;
  Status: string;
}
