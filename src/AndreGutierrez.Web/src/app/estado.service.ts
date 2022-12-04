import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Estado, GetEstadoList } from './estado';

import { MessageService } from './message.service';
import { environment } from './environment';




@Injectable({ providedIn: 'root' })
export class EstadoService {

  private estadosUrl = environment.API_URL + '/api/estados';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET estados from the server */
  getEstados(): Observable<GetEstadoList> {
    return this.http.get<GetEstadoList>(this.estadosUrl)
      .pipe(
        tap(_ => this.log('fetched estados')),
        catchError(this.handleError<GetEstadoList>('getEstados'))
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

  /** Log a EstadoService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`EstadoService: ${message}`);
  }
}