import { ForumModeratorsModelBase } from "./ForumModeratorViewModelBase";

export interface ForumModeratorsDetailsModel extends ForumModeratorsModelBase {
  ForumId: number;
  CreatedAt: Date;
  UpdatedAt: Date;
}
