export class ThreadModel {
  id: number = -1;
  title: string;
  content: string;
  locked: boolean = false;
  createdAt: Date;
  updatedAt: Date;
  postNumber: number = -1;
  parentId: number = -1;
  rootId: number = -1;
  author: string;
  forumId: number = -1;
}
