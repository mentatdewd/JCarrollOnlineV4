import { UserModelBase } from "./UserModelBase";

    export interface UserFollowersModel extends UserModelBase
    {
      Users?: UserItemModel[];
    }
}
