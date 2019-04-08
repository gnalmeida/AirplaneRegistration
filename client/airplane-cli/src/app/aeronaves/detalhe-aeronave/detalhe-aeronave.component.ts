import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";

import { AirplaneViewModel } from "../models/airplaneViewModel";
import { AirplaneService } from "../services/airplane.service";

@Component({
  selector: 'app-detalhe-aeronave',
  templateUrl: './detalhe-aeronave.component.html',
  styleUrls: ['./detalhe-aeronave.component.css']
})
export class DetalheAeronaveComponent implements OnInit {

  private id: string;
  public airplane: AirplaneViewModel;

  constructor(private service: AirplaneService,
    private router: Router, 
    private route: ActivatedRoute) { 

      this.airplane = new AirplaneViewModel();

    }

  ngOnInit() {

    this.route.params.subscribe(
      params => {
        this.id = params['id'];
      }
    );

    this.service.get(this.id)
      .subscribe((res: AirplaneViewModel) => {
        this.airplane = res;
      });
  }

}
