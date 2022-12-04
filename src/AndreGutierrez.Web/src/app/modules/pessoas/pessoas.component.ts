import { Component, OnInit } from '@angular/core';
import { Pessoa } from '../../pessoa';
import { Estado } from '../../estado';
import { PessoaService, PostPessoaRequest, PutPessoaRequest } from '../../pessoa.service';
import { EstadoService } from 'src/app/estado.service';
import { Cidade } from 'src/app/cidade';
import { CidadeService } from 'src/app/cidade.service';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.scss']
})
export class PessoasComponent implements OnInit {
  selectedPessoa?:  Pessoa;
  pessoas: Pessoa[] = [];
  cidades: Cidade[] = []

  displayedColumns: string[] = ['id', 'nome', 'idade', 'cpf', 'cidade', 'acao'];

  constructor(
    private pessoaService: PessoaService,
    private cidadeService: CidadeService) { }

  ngOnInit(): void {
    this.getPessoas();
    this.getCidades();
  }

  onNew(): void {
    this.selectedPessoa = {
      nome: "",
      cidade: { id:0 } as Cidade
    } as Pessoa;
  }

  onSave(): void {
    if(this.selectedPessoa == null) return;
    
    var id = 0;
    var nome = this.selectedPessoa.nome;
    var cpf = this.selectedPessoa.cpf;
    var idade = this.selectedPessoa.idade as Number;
    var cidadeId = this.selectedPessoa.cidade.id as Number;
    
    if(this.selectedPessoa.id == null)
    {
      this.pessoaService.addPessoa({ nome, cpf, idade, cidadeId  } as PostPessoaRequest) 
        .subscribe({
          next: () => { this.selectedPessoa = undefined; this.getPessoas(); },
          error: (error) => { alert(error.error.error.message); },
          complete: () => console.info('complete') 
        }
      );
    }
    else
    {
      var pessoaId = this.selectedPessoa.id;
      this.pessoaService.updatePessoa ({ pessoaId, nome, cpf, idade, cidadeId } as PutPessoaRequest) 
        .subscribe({
          next: () => { this.selectedPessoa = undefined; this.getPessoas(); },
          error: (error) => { alert(error.error.error.message); },
          complete: () => console.info('complete') 
        }
      );      
    }
  }

  onDelete(pessoa: Pessoa): void {
    this.pessoas = this.pessoas.filter(h => h !== pessoa);
    this.pessoaService.deletePessoa(pessoa.id)
      .subscribe({
        next: () => { this.selectedPessoa = undefined; this.getPessoas(); },
        error: (error) => { alert(error.error.error.message); },
        complete: () => console.info('complete') 
      }
    );
  }

  onSelect(pessoa: Pessoa): void {
    this.selectedPessoa = pessoa;
  }

  getPessoas(): void {
    this.pessoaService.getPessoas()
    .subscribe(pessoas => this.pessoas = pessoas.list);
  }

  getCidades(): void {
    this.cidadeService.getCidades()
    .subscribe(cidades => this.cidades = cidades.list);
  }
}