import { IModelBase } from "../IModelBase";

export interface SendCodeModel extends IModelBase {
  SelectedProvider?: string;
  //public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
  ReturnUrl?: string;
  RememberMe?: boolean;
}
