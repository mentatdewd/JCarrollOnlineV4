import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostDeleteModel extends MicropostModelBase {
  Content: string;
  Author: ApplicationUserModel;
  CreatedAt: Date;
  UpdatedAt: Date;
}
