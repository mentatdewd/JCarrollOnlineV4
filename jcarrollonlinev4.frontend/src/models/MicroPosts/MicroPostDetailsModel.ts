import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostDetailsModel extends MicropostModelBase {
  Content: string;
  Author: ApplicationUserModel;
  CreatedAt: Date;
  UpdatedAt: Date;
}
