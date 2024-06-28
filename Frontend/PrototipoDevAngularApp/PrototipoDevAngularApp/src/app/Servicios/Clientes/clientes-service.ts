import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private baseUrl = process.env['baseUrl'];

  constructor(private http: HttpClient) { }

  // Método para obtener clientes desde LINQ
  obtenerClientesLinq(): Observable<any[]> {
    const url = `${this.baseUrl}Linq`;
    return this.http.get<any[]>(url);
  }

  // Método para obtener clientes desde SP
  obtenerClientesSP(): Observable<any[]> {
    const url = `${this.baseUrl}SP`;
    return this.http.get<any[]>(url);
  }
}