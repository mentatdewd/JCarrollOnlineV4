import { IModelBase } from "../IModelBase";

export interface LoginModel extends IModelBase {
  UserName?: string;
  Password?: string;
  RememberMe?: boolean;
  ReturnUrl?: string;
  LoginProvider?: string;
}
