import { IModelBase } from "../IModelBase";

export interface VerifyCodeModel extends IModelBase {
  Provider?: string;
  Code?: string;
  ReturnUrl?: string;
  RememberBrowser?: boolean;
  RememberMe?: boolean;
}
