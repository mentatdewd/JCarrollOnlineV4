import { IModelBase } from "../IModelBase";

export interface ManageLoginsModel extends IModelBase {
  //CurrentLogins: UserLoginInfoModel[];
  //OtherLogins: AuthenticationDescription;
  StatusMessage: string;
  ShowRemoveButton: boolean;
}
