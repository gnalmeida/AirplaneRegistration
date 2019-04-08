import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, ViewContainerRef } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { Router, ActivatedRoute } from "@angular/router";

import { Observable, of } from 'rxjs';
import { fromEvent, merge } from 'rxjs';

import { AirplaneViewModel } from "../models/airplaneViewModel";
import { AirplaneService } from "../services/airplane.service";

import { GenericValidator } from "../../common/validation/generic-form-validator";

@Component({
  selector: 'app-editar-aeronave',
  templateUrl: './editar-aeronave.component.html',
  styleUrls: ['./editar-aeronave.component.css']
})
export class EditarAeronaveComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public airplaneForm: FormGroup;
  public airplane: AirplaneViewModel;
  private id: string;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  constructor(private fb: FormBuilder,
    private service: AirplaneService,
    private router: Router,
    private route: ActivatedRoute,
    vcr: ViewContainerRef) {

    this.validationMessages = {
      code: {
        required: 'O Código é requerido.',
        minlength: 'O Código precisa ter no mínimo 2 caracteres',
        maxlength: 'O Código precisa ter no máximo 20 caracteres'
      },
      model: {
        required: 'O Modelo é requerido.',
        minlength: 'O Modelo precisa ter no mínimo 2 caracteres',
        maxlength: 'O Modelo precisa ter no máximo 30 caracteres'
      },
      numberOfPassengers: {
        required: 'O Número de passageiros é requerido.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);

  }

  ngOnInit(): void {
    this.airplaneForm = this.fb.group({
      code: ['', [Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20)]],
      model: ['', [Validators.required,
        Validators.minLength(2),
        Validators.maxLength(30)]],
      numberOfPassengers: ['', Validators.required]
    });

    this.route.params.subscribe(
      params => {
        this.id = params['id'];
      }
    );

    this.service.get(this.id)
      .subscribe((res: AirplaneViewModel) => {
        this.preencherForm(res);
      });
  }

  ngAfterViewInit(): void {
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.airplaneForm);
    });
  }

  editarAeronave() {
    if (this.airplaneForm.dirty && this.airplaneForm.valid) {

      let a = Object.assign({}, this.airplane, this.airplaneForm.value);

      this.service.update(a)
        .subscribe(
          result => {
            this.onSaveComplete()
          },
          data => {
            this.onError(data);
          });
    }
  }

  preencherForm(airplaneViewModel: AirplaneViewModel): void {
    this.airplane = airplaneViewModel;

    this.airplaneForm.patchValue({
      id: this.airplane.id,
      code: this.airplane.code,
      model: this.airplane.model,
      numberOfPassengers: this.airplane.numberOfPassengers,
    });

  }

  onError(data) {
    this.errors = data.error.errors;
  }

  onSaveComplete(): void {
    alert("Alteração realizada com Sucesso!");

    this.airplaneForm.reset();
    this.errors = [];

    this.router.navigate(['/aeronaves/']);

  }

}
