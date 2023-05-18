import { IModelBase } from "../IModelBase";

export interface ManageIndexModel extends IModelBase {
  HasPassword: boolean;
  //Logins: UserLoginInfoModel;
  PhoneNumber: string;
  TwoFactor: boolean;
  BrowserRemembered: boolean;
  StatusMessage: string;
}
