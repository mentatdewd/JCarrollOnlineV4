import { IModelBase } from "../IModelBase";

export interface ExternalLoginConfirmationModel extends IModelBase
{
  SiteUserName?:   string;
  Email?: string;
  ReturnUrl?: string;
  LoginProvider?: string;
}
