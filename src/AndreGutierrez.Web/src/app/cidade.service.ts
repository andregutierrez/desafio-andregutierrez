import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Cidade, GetCidadeList, GetCidade, DeleteCidade } from './cidade';

import { MessageService } from './message.service';
import { environment } from './environment';


@Injectable({ providedIn: 'root' })
export class CidadeService {

  private cidadesUrl =  environment.API_URL + '/api/cidades'; 

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET cidades from the server */
  getCidades(): Observable<GetCidadeList> {
    return this.http.get<GetCidadeList>(this.cidadesUrl)
      .pipe(
        tap(_ => this.log('cidades carregadas')),
        catchError(this.handleError<GetCidadeList>('getCidades'))
      );
  }

  /** GET cidade by id. Will 404 if id not found */
  getCidade(id: number): Observable<GetCidade> {
    const url = `${this.cidadesUrl}/${id}`;
    return this.http.get<GetCidade>(url).pipe(
      tap(_ => this.log(`cidade carregada id=${id}`)),
      catchError(this.handleError<GetCidade>(`getCidade id=${id}`))
    );
  }

  /* GET cidades whose name contains search term */
  searchCidades(term: string): Observable<GetCidadeList> {
    if (!term.trim()) {
      // if not search term, return empty cidade array.
      return of();
    }
    return this.http.get<GetCidadeList>(`${this.cidadesUrl}/?name=${term}`).pipe(
      tap(x => x ?
         this.log(`found cidades matching "${term}"`) :
         this.log(`no cidades matching "${term}"`)),
      catchError(this.handleError<GetCidadeList>('searchCidades'))
    );
  }

  //////// Save methods //////////

  /** POST: add a new cidade to the server */
  addCidade(cidade: Cidade): Observable<GetCidade> {
    return this.http.post<GetCidade>(this.cidadesUrl, cidade, this.httpOptions).pipe(
      tap((newCidade: GetCidade) => 
        this.log(`added cidade w/ id=${newCidade?.value?.id}`)),
      catchError(this.handleError<GetCidade>('addCidade'))
    );
  }

  /** DELETE: delete the cidade from the server */
  deleteCidade(id: number): Observable<DeleteCidade> {
    const url = `${this.cidadesUrl}/${id}`;

    return this.http.delete<DeleteCidade>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted cidade id=${id}`)),
      catchError(this.handleError<DeleteCidade>('deleteCidade'))
    );
  }

  /** PUT: update the cidade on the server */
  updateCidade(cidade: Cidade): Observable<any> {
    const url = `${this.cidadesUrl}/${cidade.id}`;
    return this.http.put(url, cidade, this.httpOptions).pipe(
      map((newTag) => {
        return newTag;
      }),
      tap(_ => this.log(`updated cidade id=${cidade.id}`)),
      catchError(this.handleError<any>('updateCidade'))
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

  /** Log a CidadeService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`CidadeService: ${message}`);
  }
}