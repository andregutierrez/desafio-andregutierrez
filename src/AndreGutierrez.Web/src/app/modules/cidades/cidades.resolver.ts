import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { Cidade, GetCidadeList } from '../../cidade';
import { CidadeService } from '../../cidade.service';

@Injectable({
    providedIn: 'root'
})
export class CidadesResolver implements Resolve<any>
{
    /**
     * Constructor
     */
    constructor(private _cidadeService: CidadeService)
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
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<GetCidadeList>
    {
        return this._cidadeService.getCidades();
    }
}