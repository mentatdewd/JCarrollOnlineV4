export interface ManageIndexModel {
  HasPassword: boolean;
  //Logins: UserLoginInfoModel;
  PhoneNumber: string;
  TwoFactor: boolean;
  BrowserRemembered: boolean;
  StatusMessage: string;
}
