import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirAeronaveComponent } from './excluir-aeronave.component';

describe('ExcluirAeronaveComponent', () => {
  let component: ExcluirAeronaveComponent;
  let fixture: ComponentFixture<ExcluirAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExcluirAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExcluirAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
