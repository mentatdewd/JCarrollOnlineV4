import { ForaModelBase } from "./ForaModelBase";

export interface ForumEditModel extends ForaModelBase {
  Title?: string;
  Description?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
}
