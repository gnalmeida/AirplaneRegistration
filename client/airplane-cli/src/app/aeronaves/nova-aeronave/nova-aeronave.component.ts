import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, ViewContainerRef } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { Router } from "@angular/router";

import { Observable, of } from 'rxjs';
import { fromEvent, merge } from 'rxjs';

import { AirplaneViewModel } from "../models/airplaneViewModel";
import { AirplaneService } from "../services/airplane.service";

import { GenericValidator } from "../../common/validation/generic-form-validator";

@Component({
  selector: 'app-nova-aeronave',
  templateUrl: './nova-aeronave.component.html',
  styleUrls: ['./nova-aeronave.component.css']
})
export class NovaAeronaveComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public errors: any[] = [];
  public airplaneForm: FormGroup;
  public airplane: AirplaneViewModel;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  constructor(private fb: FormBuilder,
    private service: AirplaneService,
    private router: Router,
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
  }

  ngAfterViewInit(): void {
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.airplaneForm);
    });
  }

  adicionarAeronave() {
    if (this.airplaneForm.dirty && this.airplaneForm.valid) {

      let a = Object.assign({}, this.airplane, this.airplaneForm.value);

      this.service.add(a)
        .subscribe(
          result => {
            this.onSaveComplete()
          },
          data => {
            this.onError(data);
          });
    }
  }

  onError(data) {
    this.errors = data.error.errors;
  }

  onSaveComplete(): void {
    alert("Cadastro realizado com sucesso Sucesso!");

    this.airplaneForm.reset();
    this.errors = [];

    this.router.navigate(['/aeronaves/']);

  }

}
