import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEstacionamentoComponent } from './list-Estacionamento.component';

describe('ListInsumoComponent', () => {
  let component: ListEstacionamentoComponent;
  let fixture: ComponentFixture<ListEstacionamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListEstacionamentoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListEstacionamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
