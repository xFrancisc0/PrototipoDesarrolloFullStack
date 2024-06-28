import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../Servicios/Clientes/clientes-service' // Ajusta la ruta según la ubicación de tu servicio

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientesLinq: any[] = [];
  clientesSP: any[] = [];

  constructor(private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.obtenerClientesLinq();
    this.obtenerClientesSP();
  }

  obtenerClientesLinq() {
    this.clientesService.obtenerClientesLinq().subscribe(
      data => {
        this.clientesLinq = this.transformarTelefonos(data);
      },
      error => {
        console.error('Error al obtener clientes desde LINQ:', error);
      }
    );
  }

  obtenerClientesSP() {
    this.clientesService.obtenerClientesSP().subscribe(
      data => {
        this.clientesSP = this.transformarTelefonos(data);
      },
      error => {
        console.error('Error al obtener clientes desde SP:', error);
      }
    );
  }

  transformarTelefonos(data: any[]): any[] {
    return data.map(item => {
      if (item.telefono) {
        // Transformar el número según el formato deseado: +12 3 4567 8912
        const numeroTransformado = item.telefono.replace(/(\+\d{2})(\d)(\d{4})(\d{4})/, '$1 $2 $3 $4');
        return { ...item, telefono: numeroTransformado };
      } else {
        return item;
      }
    });
  }
}