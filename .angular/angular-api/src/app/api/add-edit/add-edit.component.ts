import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/api.service';
import { ApiComponent } from '../api.component';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],
})
export class AddEditComponent implements OnInit {
  contatosList$!: Observable<any[]>;
  pessoaTipoList$!: Observable<any[]>;

  constructor(private service: ApiService) {}

  @Input() pessoa: any;
  id: number = 0;
  nome: string = '';
  cpf: string = '';
  idade: number = 0;
  contatoId: number = 0;


  ngOnInit(): void {
    this.id = this.pessoa.id;
    this.nome = this.pessoa.nome;
    this.cpf = this.pessoa.cpf;
    this.idade = this.pessoa.idade;
    this.contatoId = this.pessoa.contatoId;
    this.contatosList$ = this.service.getContatoList();
    this.pessoaTipoList$ = this.service.getPessoaList();
  }

  addPessoa(event: any) {
    var pessoa = {
      id: 0,
      nome: event.nome,
      cpf: event.cpf,
      idade: event.idade,
      contatoId: Number(event.contatoId),
    };

    this.service.addPessoa(pessoa).subscribe((res) => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSucess = document.getElementById('add-success-alert');
      if (showAddSucess) {
        showAddSucess.style.display = 'block';
      }

      setTimeout(function () {
        if (showAddSucess) {
          showAddSucess.style.display = 'none';
        }
      }, 4000);
    });
  }


  updatePessoa(event: any) {
    var pessoa = {
      id: event.id,
      nome: event.nome,
      cpf: event.cpf,
      idade: event.idade,
      contatoId: Number(event.contatoId),
    };

    console.log(pessoa);

    this.service.updatePessoa(pessoa.id, pessoa).subscribe((res) => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSucess = document.getElementById('update-success-alert');
      if (showUpdateSucess) {
        showUpdateSucess.style.display = 'block';
      }

      setTimeout(function () {
        if (showUpdateSucess) {
          showUpdateSucess.style.display = 'none';
        }
      }, 4000);
    });
  }
}
