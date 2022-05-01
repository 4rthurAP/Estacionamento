import { EstacionamentoComponent } from './views/insumo/Estacionamento.component';
import { ListEstacionamentoComponent } from './component/list-Estacionamento/list-Estacionamento.component';
import { HomeComponent } from './views/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEstacionamentoComponent } from './component/add-Estacionamento/add-Estacionamento.component';
const routes: Routes = [

  {
    path: '',
    component: HomeComponent

  },
  {
    path: 'Estacionamento',
    component: EstacionamentoComponent
  },
  {
    path: 'list-Estacionamento',
    component: ListEstacionamentoComponent
  },
  {
    path: 'add-Estacionamento',
    component: AddEstacionamentoComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
