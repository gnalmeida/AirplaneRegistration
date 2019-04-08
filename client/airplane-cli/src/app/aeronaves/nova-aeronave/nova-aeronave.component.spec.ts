import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovaAeronaveComponent } from './nova-aeronave.component';

describe('NovaAeronaveComponent', () => {
  let component: NovaAeronaveComponent;
  let fixture: ComponentFixture<NovaAeronaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovaAeronaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovaAeronaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
