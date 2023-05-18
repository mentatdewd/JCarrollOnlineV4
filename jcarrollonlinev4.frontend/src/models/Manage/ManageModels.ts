import { IModelBase } from "../IModelBase";

export interface ManageConfigureTwoFactorModel extends IModelBase {
  SelectedProvider: string;
  //Providers: System.Web.Mvc.SelectListItem[];
}
