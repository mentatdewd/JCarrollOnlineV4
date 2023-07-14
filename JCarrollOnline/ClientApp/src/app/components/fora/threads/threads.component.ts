import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ForumModel } from '../../../models/Fora/forum.model';
import { ThreadsModel } from '../../../models/Threads/ThreadsModel';
import { fadeInOut } from '../../../services/animations';
import { ForaService } from '../../../services/fora.service';

@Component({
  selector: 'app-fora-threads',
  templateUrl: './threads.component.html',
  styleUrls: ['./threads.component.css'],
  animations: [fadeInOut]
})

export class ThreadsComponent implements OnInit {
  public threads: ThreadsModel[] = null!;
  private forumId: number;
  public forum: ForumModel;
  public isForumDataArrived: boolean = false;

  constructor(private route: ActivatedRoute, private foraService: ForaService) {
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => { this.forumId = params.forumId; });
    this.getForum();

    this.foraService.getForumThreads(this.forumId).subscribe({
      next: data => {
        console.log(data);

        this.threads = data;
        this.isForumDataArrived = true;
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

          this.forum = data;
        },
        error: error => {
          console.log(error);
        }
      });
  }

}
