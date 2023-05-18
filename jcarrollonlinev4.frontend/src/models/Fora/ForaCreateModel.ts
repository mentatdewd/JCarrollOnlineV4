import { ForaModelBase } from "./ForaModelBase";

export interface ForaCreateModel extends ForaModelBase {
  Title?: string;
  Description?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
}
