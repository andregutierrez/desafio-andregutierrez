import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { Pessoa, GetPessoaList } from '../../pessoa';
import { PessoaService } from '../../pessoa.service';

@Injectable({
    providedIn: 'root'
})
export class PessoasResolver implements Resolve<any>
{
    /**
     * Constructor
     */
    constructor(private _pessoaService: PessoaService)
    {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Resolver
     *
     * @param route
     * @param state
     */
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<GetPessoaList>
    {
        return this._pessoaService.getPessoas();
    }
}