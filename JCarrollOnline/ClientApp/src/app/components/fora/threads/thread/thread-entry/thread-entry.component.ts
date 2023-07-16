import { Component, Input, OnInit } from '@angular/core';
import { ThreadEntryNode } from '../../../../../models/threads/ThreadEntryNode.Model';
import { ForaService } from '../../../../../services/fora.service';

@Component({
  selector: 'app-thread-entry',
  templateUrl: './thread-entry.component.html',
  styleUrls: ['./thread-entry.component.scss']
})
export class ThreadEntryComponent implements OnInit {
  public postCount: number;
  public isThreadDataArrived: boolean = false;

  @Input() threadEntry: ThreadEntryNode;


  public parentThreadEntry: ThreadEntryNode;
  constructor(private foraService: ForaService) {
  }

  ngOnInit() {
    this.getParentThreadEntry();
    console.log(this.threadEntry);
    console.log(this.threadEntry.forumId);
  }

  getParentThreadEntry() {
    this.foraService.getForumThreadEntry(this.threadEntry.parentId)
      .subscribe({
        next: data => {
          console.log(data);
          this.isThreadDataArrived = true;
          this.parentThreadEntry = data;
        },
        error: error => {
          console.log(error);
        }
      });
  }
}
