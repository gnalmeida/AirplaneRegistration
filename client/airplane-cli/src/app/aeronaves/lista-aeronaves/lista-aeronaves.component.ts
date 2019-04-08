import { Component, OnInit } from '@angular/core';

import { AirplaneViewModel } from "../models/airplaneViewModel";
import { AirplaneService } from "../services/airplane.service";

@Component({
  selector: 'app-lista-aeronaves',
  templateUrl: './lista-aeronaves.component.html',
  styleUrls: ['./lista-aeronaves.component.css']
})
export class ListaAeronavesComponent implements OnInit {

  public airplanes : AirplaneViewModel[] = []; 

  errorMessage: string;

  constructor(public service: AirplaneService) { }

  ngOnInit() : void {
    
    this.service.getAll().subscribe((res : AirplaneViewModel[])=>{
      this.airplanes = res;
    });
    
  }

}
