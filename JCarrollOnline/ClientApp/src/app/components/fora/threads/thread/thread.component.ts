import { Component } from '@angular/core';
import { ThreadEntryNode } from '../../../../models/Threads/ThreadEntryNode.Model';
import { NestedTreeControl } from "@angular/cdk/tree";
import { MatTreeNestedDataSource } from "@angular/material/tree";
import { ActivatedRoute, Router } from '@angular/router';
import { ForaService } from '../../../../services/fora.service';
import { ForumModel } from '../../../../models/Fora/forum.model';

const FAKE_DATA: ThreadEntryNode[] = [
  {
    id: 1,
    title: "test title 1",
    content: "",
    locked: false,
    createdAt: new Date(),
    updatedAt: new Date(),
    postNumber: -1,
    rootId: -1,
    author: "",
    authorEmail: "",
    authorForumPostCount: -1,
    forumId: 16,
    replies: -1,
    lastReply: new Date(),
    recs: -1,
    views: -1,
    children: [
      {
        id: 2,
        title: "Reply to test title 1",
        content: "",
        locked: false,
        createdAt: new Date(),
        updatedAt: new Date(),
        postNumber: -1,
        rootId: -1,
        author: "",
        authorEmail: "",
        authorForumPostCount: -1,
        forumId: 16,
        replies: -1,
        lastReply: new Date(),
        recs: -1,
        views: -1,
        children: [
          {
            id: 3,
            title: "Reply to Reply to test title 1",
            content: "",
            locked: false,
            createdAt: new Date(),
            updatedAt: new Date(),
            postNumber: -1,
            rootId: 1,
            author: "",
            authorEmail: "",
            authorForumPostCount: -1,
            forumId: 16,
            replies: -1,
            lastReply: new Date(),
            recs: -1,
            views: -1,
            children: [],
            parentId: 2,
          },
        ],
        parentId: 1,
      },
    ],
    parentId: -1,
  }
];

/**
 * @title Tree with nested nodes
 */
@Component({
  selector: "app-thread",
  templateUrl: "./thread.component.html",
  styleUrls: ["./thread.component.css"],
})
export class ThreadComponent {
  treeControl = new NestedTreeControl<ThreadEntryNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<ThreadEntryNode>();
  public isThreadDataArrived: boolean = false;
  public forum: ForumModel;
  forumId: number;
  rootId: number;

  constructor(private route: ActivatedRoute, private foraService: ForaService) {
    this.route.queryParams.subscribe(params => { this.rootId = params['rootId']; this.forumId = params['forumId']; });

    this.getForum();

    this.foraService.getThread(this.rootId).subscribe({
      next: data => {
        console.log(data);
        //this.router..
        this.dataSource.data = data;
        this.isThreadDataArrived = true;
      },
      error: error => {
        console.log(error);
      }
    });
  }

  hasChild = (_: number, node: ThreadEntryNode) =>
    !!node.children && node.children.length > 0;

  setParent(data, parent) {
    data.parent = parent;
    if (data.children) {
      data.children.forEach(x => {
        this.setParent(x, data);
      });
    }
  }

  getForum(): void {
    this.foraService.getForum(this.forumId)
      .subscribe({
        next: data => {
          console.log(data);

          this.forum = data;
        },
        error: error => {
          console.log(error);
        }
      });
  }
}
