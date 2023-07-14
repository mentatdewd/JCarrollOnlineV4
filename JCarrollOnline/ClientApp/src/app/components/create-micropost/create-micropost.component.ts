import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { MicropostService } from '../../services/micropost.service';

@Component({
  selector: 'app-create-micropost',
  templateUrl: './create-micropost.component.html',
  styleUrls: ['./create-micropost.component.scss']
})
export class CreateMicropostComponent {
  constructor(private micropostService: MicropostService,
    private formBuilder: FormBuilder) { }

  createForm = this.formBuilder.group({
    content: '',
  });

  onSubmit() {
    this.micropostService.createMicropost(this.createForm.controls.content.value).subscribe({
      next: data => {
        console.log(data);
        this.micropostService.sendUpdate("testing");

        this.createForm.controls.content.reset();
        //this.router..
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
