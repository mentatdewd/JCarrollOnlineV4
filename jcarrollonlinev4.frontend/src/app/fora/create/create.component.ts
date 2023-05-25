import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms'
import { ForaCreateModel } from '../../../models/Fora/ForaCreateModel';
import { ForaService } from '../../../services/fora.service';

@Component({
  selector: 'app-Fora-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})

export class CreateComponent {
  constructor(http: HttpClient, private foraService: ForaService,
    private formBuilder: FormBuilder) { }

  createForm = this.formBuilder.group({
    title: '',
    description: ''
  });
  model = new ForaCreateModel();

  submitted = false;

  onSubmit() {
    this.model.title = this.createForm.controls.title.value!;
    this.model.description = this.createForm.controls.description.value!;
    this.model.id = -1;

    this.submitted = true;
    this.foraService.create(this.model).subscribe(
      (data) => {
        console.log(data);
      });
  }
}
