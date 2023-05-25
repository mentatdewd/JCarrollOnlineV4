import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms'
import { Router } from '@angular/router';
import { ForaPostModel } from '../../../models/Fora/ForaPostModel';
import { ForaService } from '../../../services/fora.service';

@Component({
  selector: 'app-fora-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})

export class CreateComponent {
  constructor(router: Router, http: HttpClient, private foraService: ForaService,
    private formBuilder: FormBuilder) { }

  createForm = this.formBuilder.group({
    title: '',
    description: ''
  });
  model = new ForaPostModel();

  onSubmit() {
    this.model.title = this.createForm.controls.title.value!;
    this.model.description = this.createForm.controls.description.value!;
    this.model.id = -1;

    this.foraService.create(this.model).subscribe({
      next: data => {
        console.log(data);
        //this.router..
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
