import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientesService } from '../../services/clientes/clientes.service'


@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [CommonModule],
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

  async obtenerClientesLinq() {
    let resultado = await this.clientesService.obtenerClientesLinq();
    if(resultado.ok){
      this.clientesLinq = this.transformarTelefonos(resultado.data.datos);
    }
  }

  async obtenerClientesSP() {
    let resultado = await this.clientesService.obtenerClientesSP();
    if(resultado.ok){
      this.clientesLinq = this.transformarTelefonos(resultado.data.datos);
    }
  }

  transformarTelefonos(data: any[]): any[] {
    let resultado = data.map(item => {
      if (item.Telefono) {
        // Transformar el número según el formato deseado: +56 9 1415 1617
        const numeroTransformado = item.Telefono.replace(/(\+\d{2})(\d)(\d{4})(\d{4})/, '$1 $2 $3 $4');
        return { ...item, Telefono: numeroTransformado }; // Ajusta Telefono según la respuesta real
      } else {
        return item;
      }
    });

    console.log(JSON.stringify(resultado));
    return resultado;
  }
}
