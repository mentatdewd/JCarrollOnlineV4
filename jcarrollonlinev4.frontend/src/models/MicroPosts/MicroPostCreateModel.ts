import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostCreateModel extends MicropostModelBase {
  Content: string;
  CreatedAt: Date;
  UpdatedAt: Date;
}
