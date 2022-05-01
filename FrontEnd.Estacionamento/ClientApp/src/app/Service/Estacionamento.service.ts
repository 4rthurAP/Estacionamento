import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { BaseResponse } from '../Models/BaseResponse';
import { Client } from '../Models/Client';


@Injectable()
export class EstacionamentoService {
constructor(private http: HttpClient) { }

    protected UrlServiceV1: string = "https://localhost:5001/";

    public obterInsumos() : Observable< BaseResponse<Client[]>> {
      return this.http.get<BaseResponse<Client[]>>(this.UrlServiceV1 + "api/V1/Insumo");
    }

    public inserirInsumos(args: any) : void {
      this.http.post(this.UrlServiceV1 + "api/V1/Insumo", args);
    }
}
