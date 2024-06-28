import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ClientesComponent } from '../Componentes/Clientes/clientes-components'; // Importa el componente

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    AppComponent,
    ClientesComponent // Agrega ClientesComponent aquí
  ],
  exports: [ClientesComponent],
  imports: [
    BrowserModule
    // Otros módulos importados aquí si es necesario
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }