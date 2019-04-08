import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { rootRouterConfig } from './app.routes';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { CollapseModule } from 'ngx-bootstrap/collapse';

import { AppComponent } from './app.component';
import { ConteudoPrincipalComponent } from './shared/conteudo-principal/conteudo-principal.component';
import { FooterComponent } from './shared/footer/footer.component';
import { MenuSuperiorComponent } from './shared/menu-superior/menu-superior.component';

import { NovaAeronaveComponent } from './aeronaves/nova-aeronave/nova-aeronave.component';
import { ListaAeronavesComponent } from './aeronaves/lista-aeronaves/lista-aeronaves.component';
import { EditarAeronaveComponent } from './aeronaves/editar-aeronave/editar-aeronave.component';
import { ExcluirAeronaveComponent } from './aeronaves/excluir-aeronave/excluir-aeronave.component';
import { DetalheAeronaveComponent } from './aeronaves/detalhe-aeronave/detalhe-aeronave.component';

import { AirplaneService } from './aeronaves/services/airplane.service';

@NgModule({
  declarations: [
    AppComponent,
    ConteudoPrincipalComponent,
    FooterComponent,
    MenuSuperiorComponent,
    ListaAeronavesComponent,
    NovaAeronaveComponent,
    EditarAeronaveComponent,
    ExcluirAeronaveComponent,
    DetalheAeronaveComponent
  ],
  imports: [
    BrowserModule,
    CollapseModule.forRoot(),
    ReactiveFormsModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: false}),
    HttpModule,
    HttpClientModule
  ],
  providers: [AirplaneService],
  bootstrap: [AppComponent]
})
export class AppModule { }
