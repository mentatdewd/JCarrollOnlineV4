export interface VerifyCodeModel {
  Provider?: string;
  Code?: string;
  ReturnUrl?: string;
  RememberBrowser?: boolean;
  RememberMe?: boolean;
}
