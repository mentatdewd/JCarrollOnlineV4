import { ApplicationUserModel } from "./Users/ApplicationUserModel";

export interface MicropostNotificationEmailModel {
  MicropostAuthor: ApplicationUserModel;
  MicropostContent: string;
}
