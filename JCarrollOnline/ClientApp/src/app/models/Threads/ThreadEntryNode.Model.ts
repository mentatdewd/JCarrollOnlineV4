export interface ThreadEntryNode {
  id: number;
  title: string;
  content: string;
  locked: boolean;
  createdAt: Date;
  updatedAt: Date;
  postNumber: number;
  rootId: number;
  author: string;
  authorEmail: string;
  authorForumPostCount: number;
  forumId: number;
  replies: number;
  lastReply: Date;
  recs: number;
  views: number;
  children: ThreadEntryNode[];
  parentId: number;
}
