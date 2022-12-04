import { Component, OnInit } from '@angular/core';
import { Cidade } from '../../cidade';
import { Estado } from '../../estado';
import { CidadeService } from '../../cidade.service';
import { EstadoService } from 'src/app/estado.service';

@Component({
  selector: 'app-cidades',
  templateUrl: './cidades.component.html',
  styleUrls: ['./cidades.component.scss']
})
export class CidadesComponent implements OnInit {
  selectedCidade?:  Cidade;
  cidades: Cidade[] = [];
  estados: Estado[] = [ 
    {uf: 'AC'}, {uf: 'AL'}, {uf: 'AP'}, {uf: 'AM'}, {uf: 'BA'}, {uf: 'CE'},
    {uf: 'ES'}, {uf: 'GO'}, {uf: 'MA'}, {uf: 'MT'}, {uf: 'MS'}, {uf: 'MG'},
    {uf: 'PA'}, {uf: 'PB'}, {uf: 'PR'}, {uf: 'PE'}, {uf: 'PI'}, {uf: 'RJ'},
    {uf: 'RN'}, {uf: 'RS'}, {uf: 'RO'}, {uf: 'RR'}, {uf: 'SC'}, {uf: 'SP'},
    {uf: 'SE'}, {uf: 'TO'}
  ];
  displayedColumns: string[] = ['id', 'nome', 'uf', 'acao'];

  constructor(private cidadeService: CidadeService) { }

  ngOnInit(): void {
    this.getCidades();
  }

  onNew(): void {
    this.selectedCidade = {} as Cidade;
  }

  onSave(): void {
    if(this.selectedCidade == null) return;

    var nome = this.selectedCidade.nome;
    var uf = this.selectedCidade.uf;

    if(this.selectedCidade.id == null)
    {
      this.cidadeService.addCidade({ nome, uf  } as Cidade) 
        .subscribe({
          next: () => { this.selectedCidade = undefined; this.getCidades(); },
          error: (error) => { alert(error.error.error.message); },
          complete: () => console.info('complete') 
        }
      );
    }
    else
    {
      var id = this.selectedCidade.id;
      this.cidadeService.updateCidade ({ id, nome, uf  } as Cidade) 
        .subscribe({
          next: () => { this.selectedCidade = undefined; this.getCidades(); },
          error: (error) => { alert(error.error.error.message); },
          complete: () => console.info('complete') 
        }
      );      
    }
  }

  onDelete(cidade: Cidade): void {
    this.cidades = this.cidades.filter(h => h !== cidade);
    this.cidadeService.deleteCidade(cidade.id)
      .subscribe({
        next: () => { this.selectedCidade = undefined; this.getCidades(); },
        error: (error) => { alert(error.error.error.message); },
        complete: () => console.info('complete') 
      }
    );
  }

  onSelect(cidade: Cidade): void {
    this.selectedCidade = cidade;
  }

  getCidades(): void {
    this.cidadeService.getCidades()
    .subscribe(cidades => this.cidades = cidades.list);
  }
}