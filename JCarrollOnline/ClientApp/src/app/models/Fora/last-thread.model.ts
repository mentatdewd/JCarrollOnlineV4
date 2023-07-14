import { ForumModel } from "./forum.model";

export class LastThreadModel {
  updatedAt: Date;
  title: string;
  postRoot: number;
  postNumber: number;
  author: string;
  Forum: ForumModel;
}
