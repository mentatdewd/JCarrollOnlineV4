import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ForaGetModel } from '../../models/Fora/ForaGetModel';
import { ForaService } from '../../services/fora.service';

@Component({
  selector: 'app-fora',
  templateUrl: './fora.component.html',
  styleUrls: ['./fora.component.css']
})

export class ForaComponent {
  public fora?: ForaGetModel[];

  constructor(private router: Router, http: HttpClient, private foraService: ForaService,
    private formBuilder: FormBuilder) {
    foraService.get().subscribe(fora => this.fora = fora);
  }
}
