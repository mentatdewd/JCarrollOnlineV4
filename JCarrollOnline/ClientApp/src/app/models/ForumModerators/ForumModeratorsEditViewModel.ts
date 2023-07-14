import { ForumModeratorsModelBase } from "./ForumModeratorViewModelBase";

export interface ForumModeratorsEditModel extends ForumModeratorsModelBase
{
  ForumId: number;
  CreatedAt: Date;
  UpdatedAt: Date;
}
