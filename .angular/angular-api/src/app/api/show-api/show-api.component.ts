import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-show-api',
  templateUrl: './show-api.component.html',
  styleUrls: ['./show-api.component.css'],
})
export class ShowApiComponent implements OnInit {
  apiFuncList$!: Observable<any[]>;
  apiTiposList$!: Observable<any[]>;
  apiTiposList: any = [];

  apiTiposMap: Map<number, string> = new Map();

  constructor(private service: ApiService) {}

  ngOnInit(): void {
    this.apiFuncList$ = this.service.getPessoaList();
    this.apiTiposList$ = this.service.getContatoList();
    this.refleshApiFuncContatoMap();
    this.modalAdd()
  }

  //Variáveis (Propriedades)
  modalTitle: string = '';
  activateAddEditApiComponent: boolean = false;
  pessoa: any;

  modalAdd() {
    this.pessoa = {
      id: 0,
      TipoContato: '',
      contatoId: null
    }

    this.modalTitle = "Nova Pessoa";
    this.activateAddEditApiComponent = true;
  }

  modalEdit(item:any){
    this.pessoa = item;
    this.modalTitle = "Edição de Tarefa";
    this.activateAddEditApiComponent = true;

  }

  delete(item:any) {

    if (confirm(`Você tem certeza que deseja deletar esse item? ${item.id}?`)) {
      this.service.deletePessoa(item.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        console.log(item.id);
        debugger


        var showDeleteSucess = document.getElementById('delete-success-alert');
        if (showDeleteSucess) {
          showDeleteSucess.style.display = 'block';
        }

        setTimeout(function () {
          if (showDeleteSucess) {
            showDeleteSucess.style.display = 'none';
          }
        }, 4000);
      });
    }
  }

  modalClose() {
    this.activateAddEditApiComponent = false;
    this.apiFuncList$ = this.service.getPessoaList();
  }

  refleshApiFuncContatoMap() {
    this.service.getContatoList().subscribe((data) => {
      this.apiTiposList = data;

      for (let i = 0; i < data.length; i++) {
        this.apiTiposMap.set(
          this.apiTiposList[i].id,
          this.apiTiposList[i].tipoContato
        );
      }
    });
  }
}
