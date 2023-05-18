import { ApplicationUserModel } from "./Users/ApplicationUserModel";

export interface EmailModelBase {
  TargetUser: ApplicationUserModel;
  Content: string;
}
