import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ThreadEntryNode } from '../../../../../models/threads/ThreadEntryNode.Model';
import { ForaService } from '../../../../../services/fora.service';

@Component({
  selector: 'app-thread-root',
  templateUrl: './thread-root.component.html',
  styleUrls: ['./thread-root.component.scss']
})
export class ThreadRootComponent implements OnInit {
  public thread: ThreadEntryNode;
  public postCount: number;
  public isThreadDataArrived: boolean = false;

  @Input('rootId') rootId: number;
  @Input('forumId') forumId: number;

  constructor(private route: ActivatedRoute, private foraService: ForaService) {
  }

  ngOnInit() {
    //this.route.queryParams.subscribe(params => { this.rootId = params.rootId; });
    this.foraService.getForumThreadEntry(this.rootId).subscribe({
      next: data => {
        console.log(data);
        //this.router..
        this.thread = data;
        this.isThreadDataArrived = true;
      },
      error: error => {
        console.log(error);
      }
    });

  }

}
