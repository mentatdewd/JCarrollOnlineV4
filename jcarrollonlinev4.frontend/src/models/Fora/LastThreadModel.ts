import { ForaModel } from "./ForaModel";
import { ForaModelBase } from "./ForaModelBase";

export interface LastThreadModel extends ForaModelBase {
  UpdatedAt: Date;
  Title?: string;
  PostRoot: number;
  PostNumber: number;
  Author?: string;
  Forum?: ForaModel;
}
