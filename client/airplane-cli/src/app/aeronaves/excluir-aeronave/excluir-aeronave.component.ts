import { Component, OnInit, ViewContainerRef, ViewChildren, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { FormControlName } from "@angular/forms";
import { Subscription } from "rxjs";

import { AirplaneViewModel } from "../models/airplaneViewModel";
import { AirplaneService } from "../services/airplane.service";

@Component({
  selector: 'app-excluir-aeronave',
  templateUrl: './excluir-aeronave.component.html',
  styleUrls: ['./excluir-aeronave.component.css']
})
export class ExcluirAeronaveComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public sub: Subscription;
  public errors: any[] = [];
  public airplane: AirplaneViewModel;
  private id: string;

  constructor(private service: AirplaneService,
    private route: ActivatedRoute,
    private router: Router,
    vcr: ViewContainerRef) {

      this.airplane = new AirplaneViewModel();

  }

  ngOnInit() {

    this.sub = this.route.params.subscribe(
      params => {
        this.id = params['id'];
      });

    this.service.get(this.id)
      .subscribe((res: AirplaneViewModel) => {
        this.airplane = res;
      });

  }

  excluirAeronave() {

    this.service.delete(this.id)
      .subscribe(
        result => {
          this.onSaveComplete()
        },
        data => {
          this.onError(data);
        });

  }

  onError(data) {
    this.errors = data.error.errors;
  }

  onSaveComplete(): void {
    alert("Exclusão realizada com Sucesso!");

    this.router.navigate(['/aeronaves/']);
  }

}
