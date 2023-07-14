import { ForumModeratorsModelBase } from "./ForumModeratorViewModelBase";

export interface ForumModeratorsIndexModel extends ForumModeratorsModelBase {
  ForumId: number;
  CreatedAt: Date;
  UpdatedAt: Date;
}
