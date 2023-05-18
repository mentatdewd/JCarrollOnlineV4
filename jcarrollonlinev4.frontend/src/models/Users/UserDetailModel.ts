import { UserInfoModel } from "../user-info";
import { UserModelBase } from "./UserModelBase";

    export interface UserDetailModel extends UserModelBase
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();
      UserItemModel?: UserInfoModel;
      UserStatsModel?: UserStatsModel;
    }
}
