import { ForumModeratorsModelBase } from "./ForumModeratorViewModelBase";

export interface ForumModeratorsDeleteModel extends ForumModeratorsModelBase {
  ForumId: number;
  CreatedAt: Date;
  UpdatedAt: Date;
}
