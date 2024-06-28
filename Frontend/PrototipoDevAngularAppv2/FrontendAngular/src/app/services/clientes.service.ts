import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../Environment/Environment'

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Método para obtener clientes desde LINQ
  obtenerClientesLinq(): Observable<any[]> {
    const url = `${this.baseURL}Linq`;
    return this.http.get<any[]>(url);
  }

  // Método para obtener clientes desde SP
  obtenerClientesSP(): Observable<any[]> {
    const url = `${this.baseURL}SP`;
    return this.http.get<any[]>(url);
  }
}