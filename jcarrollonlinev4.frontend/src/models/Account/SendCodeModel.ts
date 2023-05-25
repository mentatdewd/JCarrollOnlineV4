export interface SendCodeModel {
  SelectedProvider?: string;
  //public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
  ReturnUrl?: string;
  RememberMe?: boolean;
}
