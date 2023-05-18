import { IModelBase } from "../IModelBase";

export interface DeleteUserModel extends IModelBase{
  Id?: string;
  UserName?: string;
  Email?: string;
}
