import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { MaterialModule } from '../material.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MessagesComponent } from './messages/messages.component';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MenuComponent } from './menu/menu.component';

import { PessoasComponent } from './modules/pessoas/pessoas.component';
import { CidadesComponent } from './modules/cidades/cidades.component';
import { CidadesResolver } from './modules/cidades/cidades.resolver';
import { PessoasResolver } from './modules/pessoas/pessoas.resolver';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    MenuComponent,
    PessoasComponent,
    CidadesComponent,
    MessagesComponent
  ],
  imports: [
    MaterialModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'cidades', component: CidadesComponent, resolve : { tags: CidadesResolver} },
      { path: 'pessoas', component: PessoasComponent, resolve : { tags: PessoasResolver} },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
