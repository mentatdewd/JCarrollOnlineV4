import { ForaModelBase } from "./ForaModelBase";

export interface ForumDeleteModel extends ForaModelBase
{
  Title?: string;
  Description?: string;
  CreatedAt: Date;
  UpdatedAt: Date;
}
