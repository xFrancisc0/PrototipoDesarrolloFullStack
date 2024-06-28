import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { HttpClientModule, HttpClient, withFetch, provideHttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent  // Añade aquí tu componente
  ],
  imports: [
    BrowserModule, HttpClientModule, CommonModule
  ],
  providers: [HttpClient, provideHttpClient(withFetch())],
  bootstrap: [AppComponent]
})
export class AppModule { }