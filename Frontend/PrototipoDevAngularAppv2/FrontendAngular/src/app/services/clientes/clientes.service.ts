import { Injectable } from '@angular/core';
import { provideHttpClient, withFetch, HttpClient } from '@angular/common/http';
import { environment } from '../../../Environment/Environment'

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) { }

  async obtenerClientesLinq(): Promise<any>{
    // Ignorar temporalmente los errores de certificado (NO RECOMENDADO)
    //process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
    let respuesta = (await fetch(this.baseURL + 'Linq')).text();

    return JSON.parse(await respuesta);
  }

  async obtenerClientesSP(): Promise<any>{
    // Ignorar temporalmente los errores de certificado (NO RECOMENDADO)
    //process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
    let respuesta = (await fetch(this.baseURL + 'SP')).text();

    return JSON.parse(await respuesta);
  }

}