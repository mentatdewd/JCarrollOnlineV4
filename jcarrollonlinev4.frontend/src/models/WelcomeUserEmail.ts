import { EmailModelBase } from "./EmailModelBase";

export interface UserWelcomeViewModel extends EmailModelBase {
  CallbackUrl: URL;
  //public bool IsPremiumUser { get; set; }
}
