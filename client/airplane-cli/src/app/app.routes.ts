import { Routes } from '@angular/router';

import { ListaAeronavesComponent } from './aeronaves/lista-aeronaves/lista-aeronaves.component';
import { NovaAeronaveComponent } from './aeronaves/nova-aeronave/nova-aeronave.component';
import { EditarAeronaveComponent } from './aeronaves/editar-aeronave/editar-aeronave.component';
import { ExcluirAeronaveComponent } from './aeronaves/excluir-aeronave/excluir-aeronave.component';
import { DetalheAeronaveComponent } from './aeronaves/detalhe-aeronave/detalhe-aeronave.component';

export const rootRouterConfig: Routes = [
    {path: '', redirectTo: 'aeronaves', pathMatch: 'full' },
    {path: 'aeronaves', component: ListaAeronavesComponent },
    {path: 'nova-aeronave', component: NovaAeronaveComponent },
    {path: 'editar-aeronave/:id', component: EditarAeronaveComponent },
    {path: 'excluir-aeronave/:id', component: ExcluirAeronaveComponent },
    {path: 'detalhe-aeronave/:id', component: DetalheAeronaveComponent }   
]