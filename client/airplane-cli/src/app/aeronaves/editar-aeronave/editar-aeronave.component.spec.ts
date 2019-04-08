import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarAeronaveComponent } from './editar-aeronave.component';

describe('EditarAeronaveComponent', () => {
  let component: EditarAeronaveComponent;
  let fixture: ComponentFixture<EditarAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
