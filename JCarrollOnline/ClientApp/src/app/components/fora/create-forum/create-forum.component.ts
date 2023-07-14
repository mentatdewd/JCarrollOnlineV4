import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ForaModel } from '../../../models/Fora/fora.model';
import { ForumModel } from '../../../models/Fora/forum.model';
import { fadeInOut } from '../../../services/animations';
import { ForaService } from '../../../services/fora.service';

@Component({
  selector: 'app-create-forum',
  templateUrl: './create-forum.component.html',
  styleUrls: ['./create-forum.component.scss'],
  animations: [fadeInOut]
})

export class CreateForumComponent implements OnInit {
  public isForumDataArrived: boolean = false;
  public forum: ForaModel;
  public forumId: number;
  public rootThreadEntryId: number;

  constructor(private router: Router,
    private foraService: ForaService,
    private formBuilder: FormBuilder) { }

  createForm = this.formBuilder.group({
    title: '',
    description: ''
  });
  model = new ForumModel();

  ngOnInit() {
  }

  onSubmit() {
    this.model.title = this.createForm.controls.title.value!;
    this.model.description = this.createForm.controls.description.value!;
    this.model.id = -1;

    this.foraService.createForum(this.model).subscribe({
      next: data => {
        console.log(data);
        // Page redirect when getting response
        this.router.navigate(['./fora']);
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
