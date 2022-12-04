import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Pessoa, GetPessoaList, GetPessoa, PutPessoa, DeletePessoa } from './pessoa';

import { MessageService } from './message.service';
import { environment } from './environment';


@Injectable({ providedIn: 'root' })
export class PessoaService {

  private pessoasUrl = environment.API_URL + '/api/pessoas';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET pessoas from the server */
  getPessoas(): Observable<GetPessoaList> {
    return this.http.get<GetPessoaList>(this.pessoasUrl)
      .pipe(
        tap(_ => this.log('fetched pessoas')),
        catchError(this.handleError<GetPessoaList>('getPessoas'))
      );
  }

  /** GET pessoa by id. Return `undefined` when id not found */
  getPessoaNo404<Data>(id: number): Observable<GetPessoa> {
    const url = `${this.pessoasUrl}/?id=${id}`;
    return this.http.get<GetPessoa[]>(url)
      .pipe(
        map(pessoas => pessoas[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? 'fetched' : 'did not find';
          this.log(`${outcome} pessoa value.id=${id}`);
        }),
        catchError(this.handleError<GetPessoa>(`getPessoa id=${id}`))
      );
  }

  /** GET pessoa by id. Will 404 if id not found */
  getPessoa(id: number): Observable<GetPessoa> {
    const url = `${this.pessoasUrl}/${id}`;
    return this.http.get<GetPessoa>(url).pipe(
      tap(_ => this.log(`fetched pessoa value.id=${id}`)),
      catchError(this.handleError<GetPessoa>(`getPessoa id=${id}`))
    );
  }

  /* GET pessoas whose name contains search term */
  searchPessoas(term: string): Observable<GetPessoaList> {
    if (!term.trim()) {
      // if not search term, return empty pessoa array.
      return of();
    }
    return this.http.get<GetPessoaList>(`${this.pessoasUrl}/?name=${term}`).pipe(
      tap(x => x ?
         this.log(`found pessoas matching "${term}"`) :
         this.log(`no pessoas matching "${term}"`)),
      catchError(this.handleError<GetPessoaList>('searchPessoas'))
    );
  }

  //////// Save methods //////////

  /** POST: add a new pessoa to the server */
  addPessoa(pessoa: PostPessoaRequest): Observable<GetPessoa> {
    return this.http.post<GetPessoa>(this.pessoasUrl, pessoa, this.httpOptions).pipe(
      tap((newPessoa: GetPessoa) => this.log(`added pessoa w/ id=${newPessoa?.value?.id}`)),
      catchError(this.handleError<GetPessoa>('addPessoa'))
    );
  }

  /** DELETE: delete the pessoa from the server */
  deletePessoa(id: number): Observable<DeletePessoa> {
    const url = `${this.pessoasUrl}/${id}`;

    return this.http.delete<DeletePessoa>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted pessoa id=${id}`)),
      catchError(this.handleError<DeletePessoa>('deletePessoa'))
    );
  }

  /** PUT: update the pessoa on the server */
  updatePessoa(pessoa: PutPessoaRequest): Observable<any> {
    const url = `${this.pessoasUrl}/${pessoa.pessoaId}`;
    return this.http.put(url, pessoa, this.httpOptions).pipe(
      map((newTag) => {
        return newTag;
      }),
      tap(_ => this.log(`updated pessoa id=${pessoa.pessoaId}`)),
      catchError(this.handleError<any>('updatePessoa'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (e: any): Observable<T> => {
      
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${e.message}`);

      // Let the app keep running by returning an empty result.
      return throwError(() => e);
    };
  }

  /** Log a PessoaService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`PessoaService: ${message}`);
  }
}

export interface PostPessoaRequest {
  nome: string;
  cpf: string;
  idade: number;
  cidadeId: number;
}

export interface PutPessoaRequest {
  pessoaId: number;
  nome: string;
  cpf: string;
  idade: number;
  cidadeId: number;
}