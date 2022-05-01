import { Component, OnInit } from '@angular/core';
import { EstacionamentoService } from 'src/app/Service/Estacionamento.service';

@Component({
  selector: 'app-list-Estacionamento',
  templateUrl: './list-Estacionamento.component.html',
  styleUrls: ['./list-Estacionamento.component.css'],
})

export class ListEstacionamentoComponent implements OnInit {
  displayedColumns: string[] = ['nome', 'dataCompra','valor' , 'precoUnit'];
  dataSource: any;
  constructor(private service: EstacionamentoService) {
   }

   ngOnInit(): void {

    //this.dataSource = this.insumoService.obterInsumos().subscribe(e => this.dataSource = e.Data);
     this.service.obterInsumos().subscribe(
      { next: base => {
        let x = base;
        this.dataSource = x.data;
        console.log(this.dataSource);
      }}
    );
  }
}
