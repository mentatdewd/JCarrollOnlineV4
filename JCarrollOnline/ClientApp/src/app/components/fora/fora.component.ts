import { Component, OnInit } from '@angular/core';
import { ForaModel } from '../../models/Fora/fora.model';
import { fadeInOut } from '../../services/animations';
import { ForaService } from '../../services/fora.service';

@Component({
  selector: 'app-fora',
  templateUrl: './fora.component.html',
  styleUrls: ['./fora.component.css'],
  animations: [fadeInOut]
})

export class ForaComponent implements OnInit {
  fora: ForaModel[] = [];
  _foraService: ForaService;

  constructor(private foraService: ForaService) {
    this._foraService = foraService;
  }
  ngOnInit() {
    this.foraService.getAllFora().subscribe({
      next: data => {
        console.log(data);
        //this.router..
        this.fora = data;
      },
      error: error => {
        console.log(error);
      }
    });
  }
}
