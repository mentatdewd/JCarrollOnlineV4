import { RssFeedModelBase } from "./RssFeedModelBase";

export interface RssFeedItemModel extends RssFeedModelBase {
  Link: URL;
  UpdatedAt: Date;
  Title: string;
}
