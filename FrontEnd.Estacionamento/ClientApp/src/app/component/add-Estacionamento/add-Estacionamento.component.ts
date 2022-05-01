import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EstacionamentoService } from 'src/app/Service/Estacionamento.service';

@Component({
  selector: 'app-add-Estacionamento',
  templateUrl: './add-Estacionamento.component.html',
  styleUrls: ['./add-Estacionamento.component.css']
})

export class AddEstacionamentoComponent implements OnInit {
  isLinear = false;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  control!: FormControl;
  constructor(private _formBuilder: FormBuilder, private service: EstacionamentoService)
  {
  }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      tituloInsumo: ['', Validators.required],
      ingredientes: ['', Validators.required],
      modoDePreparo: ['', Validators.required],
    });
  }

  public Save()
  {
    console.log(this.firstFormGroup.value)
    this.service.inserirInsumos(this.firstFormGroup.value);
  }
}
