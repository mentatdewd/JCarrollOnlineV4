import { ApplicationUserModel } from "./Users/ApplicationUserModel";

    export interface MicropostNotificationEmailModel extends EmailModelBase
    {
      MicropostAuthor: ApplicationUserModel;
      MicropostContent: string;
    }
}
