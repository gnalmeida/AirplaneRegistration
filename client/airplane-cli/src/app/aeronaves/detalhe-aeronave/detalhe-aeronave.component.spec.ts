import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalheAeronaveComponent } from './detalhe-aeronave.component';

describe('DetalheAeronaveComponent', () => {
  let component: DetalheAeronaveComponent;
  let fixture: ComponentFixture<DetalheAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalheAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalheAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
