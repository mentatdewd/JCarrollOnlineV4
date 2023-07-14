import { ForumModeratorsModelBase } from "./ForumModeratorViewModelBase";

export interface ForumModeratorsCreateModel extends ForumModeratorsModelBase {
  ForumId: number;
  CreatedAt: Date;
  UpdatedAt: Date;
}
