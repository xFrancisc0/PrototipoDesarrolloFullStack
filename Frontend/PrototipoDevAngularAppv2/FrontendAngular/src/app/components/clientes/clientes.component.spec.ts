// Pipe para prueba de transformacion de teléfonos con Jasmine
import { TestBed } from '@angular/core/testing';
import { ClientesComponent } from './clientes.component';

describe('ClientesComponent', () => {
  let component: ClientesComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientesComponent]
    });

    component = TestBed.inject(ClientesComponent);
  });

  it('Se genera método para pruebas unitarias al pipe de transformacion de telefonos', () => {
    const testData = [
      { Id: 1, DNI: '12345678', ClienteNombre: 'Juan', ApellidoP: 'Pérez', ApellidoM: 'González', Telefono: '+56912345678', PaisNombre: 'Chile' },
      { Id: 2, DNI: '87654321', ClienteNombre: 'María', ApellidoP: 'López', ApellidoM: 'Martínez', Telefono: '+56991011123', PaisNombre: 'España' },
      { Id: 3, DNI: '56781234', ClienteNombre: 'Carlos', ApellidoP: 'Gómez', ApellidoM: 'Rodríguez', Telefono: '+56914151617', PaisNombre: 'China' }
    ];

    const transformedData = component.transformarTelefonos(testData);

    expect(transformedData.length).toBe(3);
    expect(transformedData[0].Telefono).toBe('+56 9 1234 5678');
    expect(transformedData[1].Telefono).toBe('+56 9 1011 1123');
    expect(transformedData[2].Telefono).toBe('+56 9 1415 1617');
  });
});