import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ForumModel } from '../../../../models/Fora/forum.model';
import { ThreadModel } from '../../../../models/threads/ThreadModel';
import { fadeInOut } from '../../../../services/animations';
import { ForaService } from '../../../../services/fora.service';

@Component({
  selector: 'app-thread-create',
  templateUrl: './thread-create.component.html',
  styleUrls: ['./thread-create.component.scss'],
  animations: [fadeInOut]
})

export class ThreadCreateComponent implements OnInit {
  model = new ThreadModel();
  createForm: FormGroup;
  public forum: ForumModel;
  public isForumDataArrived: boolean = false;
  public forumId: number;

  constructor(public router: Router, private foraService: ForaService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        console.log(params); // { order: "popular" }

        this.forumId = params.forumId;

        console.log(this.forumId); // popular
      }
      );

    this.getForum();

    this.createForm = this.formBuilder.group({
      title: '',
      content: ''
    });
  }

  getForum(): void {
    this.foraService.getForum(this.forumId)
      .subscribe({
        next: data => {
          console.log(data);

          this.forum = data;
          this.isForumDataArrived = true;
        },
        error: error => {
          console.log(error);
        }
      });
  }

  onSubmit() {
    this.model.title = this.createForm.controls.title.value!;
    this.model.content = this.createForm.controls.content.value!;
    this.model.id = -1;
    this.model.author = "";
    this.model.forumId = this.forumId;
    this.model.locked = false;
    this.model.parentId = -1;
    this.model.postNumber = -1;
    this.model.rootId = -1;

    this.foraService.threadCreate(this.model).subscribe({
      next: data => {
        console.log(data);
        // Page redirect when getting response
        this.router.navigate(['./fora/threads'], { queryParams: { forumId: this.forumId } });
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
