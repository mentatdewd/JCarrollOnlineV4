import { ApplicationUserModelBase } from "./ApplicationUserModelBase";

    export interface ApplicationUserModel extends ApplicationUserModelBase
    {
      Id?: string;
      Email?: string;
      UserName?: string;
      MicroPostEmailNotifications: boolean;
      MicroPostSMSNotifications: boolean;
    }
