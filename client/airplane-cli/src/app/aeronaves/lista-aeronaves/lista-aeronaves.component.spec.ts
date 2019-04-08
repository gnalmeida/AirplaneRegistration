import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAeronavesComponent } from './lista-aeronaves.component';

describe('ListaAeronavesComponent', () => {
  let component: ListaAeronavesComponent;
  let fixture: ComponentFixture<ListaAeronavesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAeronavesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAeronavesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
