import { Routes } from '@angular/router';
import { ClientesComponent } from '../Componentes/Clientes/clientes-components';

export const routes: Routes = [{ path: 'clientes', component: ClientesComponent },
                               { path: '**', redirectTo: '' }];
