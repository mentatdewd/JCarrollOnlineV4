import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EditorInstance, EditorOption } from 'angular-markdown-editor';
import { ForumModel } from '../../../../../models/Fora/forum.model';
import { ThreadEntryNode } from '../../../../../models/Threads/ThreadEntryNode.Model';
import { fadeInOut } from '../../../../../services/animations';
import { ForaService } from '../../../../../services/fora.service';
import { MarkdownService } from 'ngx-markdown';

@Component({
  selector: 'app-thread-reply',
  templateUrl: './thread-reply.component.html',
  styleUrls: ['./thread-reply.component.scss'],
  animations: [fadeInOut]
})

export class ThreadReplyComponent implements OnInit {
  model: ThreadEntryNode;
  parentEntry: ThreadEntryNode;
  parentId: number;
  forumId: number;
  replyForm: FormGroup;
  public forum: ForumModel;
  public isForumDataArrived: boolean = false;
  public isParentDataArrived: boolean = false;
  bsEditorInstance!: EditorInstance;
  markdownText = '';
  showEditor = true;
  templateForm!: FormGroup;
  editorOptions!: EditorOption;

  constructor(public router: Router,
    private _route: ActivatedRoute,
    private foraService: ForaService,
    private formBuilder: FormBuilder,
    private markdownService: MarkdownService) { }

  ngOnInit() {
    this._route.queryParams.subscribe(params => {
      this.parentId = params['parentId'];
      this.forumId = params['forumId'];
    });

    this.getForum();
    this.getParentEntry();

  //  this.replyForm = this.formBuilder.group({
  //    title: '',
  //    content: ''
  //  });
    this.templateForm = this.formBuilder.group({
      body: [this.markdownText],
      isPreview: [true]
    });

    this.editorOptions = {
      parser: (val) => this.markdownService.parse(val.trim())
    };
  }

  hidePreview() {
    if (this.bsEditorInstance && this.bsEditorInstance.hidePreview) {
      this.bsEditorInstance.hidePreview();
    }
  }

  highlight() {
    setTimeout(() => {
      this.markdownService.highlight();
    });
  }


  getParentEntry(): void {
    this.foraService.getForumThreadEntry(this.parentId)
      .subscribe({
        next: data => {
          console.log(data);
          //this.router..
          this.parentEntry = data;
          this.isParentDataArrived = true;
        },
        error: error => {
          console.log(error);
        }
      });
  }

  getForum(): void {
    this.foraService.getForum(this.forumId)
      .subscribe({
        next: data => {
          console.log(data);
          //this.router..
          this.forum = data;
          this.isForumDataArrived = true;
        },
        error: error => {
          console.log(error);
        }
      });
  }

  onSubmit() {
    let myobj = {
      id: -1,
      title: this.replyForm.controls.title.value!,
      content: this.replyForm.controls.content.value!,
      locked: false,
      createdAt: new Date(),
      updatedAt: new Date(),
      postNumber: -1,
      rootId: -1,
      author: "",
      authorEmail: "",
      authorForumPostCount: -1,
      forumId: this.parentEntry.forumId,
      replies: -1,
      lastReply: new Date(),
      recs: -1,
      views: -1,
      children: [],
      parentId: this.parentEntry.id,
    }

    this.foraService.threadReply(myobj).subscribe({
      next: data => {
        console.log(data);
        // Page redirect when getting response
        this.router.navigate(['./fora/threads/thread'], { queryParams: { rootId: this.parentEntry.rootId, forumId: this.parentEntry.forumId } });
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
