import { ApplicationUserModel } from "../Users/ApplicationUserModel";
import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostIndexModel extends MicropostModelBase {
  Content: string;
  Author: ApplicationUserModel;
  CreatedAt: Date;
  UpdatedAt: Date;
}
