import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { delay, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  readonly apiFunc = "https://localhost:7060/api";

  constructor(private http: HttpClient) { }

  getPessoaList():Observable<[]>{
    return this.http.get<any>(this.apiFunc + '/Pessoa');
  }

  addPessoa(data:any){
    return this.http.post(this.apiFunc + '/Pessoa', data);
  }

  updatePessoa(id:number, data:any){
    return this.http.put(this.apiFunc + `/Pessoa/${id}`, data);
  }

  deletePessoa(id:number|string){
    return this.http.delete(this.apiFunc + `/Pessoa/${id}`);
  }

  getContatoList():Observable<[]>{
    return this.http.get<any>(this.apiFunc + '/Contato');
  }

  addContato(data:any){
    return this.http.post(this.apiFunc + '/Contato',data);
  }

  updateContato(id:number|string, data:any){
    return this.http.put(this.apiFunc + `/Contato/${id}`, data);
  }

  deleteContato(id:number|string){
    return this.http.delete(this.apiFunc + `/Contato/${id}`);
  }
}

