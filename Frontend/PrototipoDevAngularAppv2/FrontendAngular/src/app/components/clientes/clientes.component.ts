import { Component } from '@angular/core';
import { ClientesService } from '../../services/clientes.service'
@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [],
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css'
})
export class ClientesComponent {
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
