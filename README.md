Pasos para probarlo
1.- Backend/DB, hay algunas instrucciones para instanciar la base de datos de mssql en docker de una manera muy rápida.
2.- Backend/API, hay que ejecutar esta API en Visual Studio 2022. Los paquetes que no esten se pueden bajar como NuGet.
3.- Frontend/PrototipoDevAngularAppv2/FrontendAngular, hay que ejecutarlo con vscode, ng serve. Los paquetes que no esten: npm i.

Para entrar a la aplicacion Angular: http://localhost:4200.
En caso de que la HTTPRequest para obtener la data de la API no funcione, en src/app/services/clientes.service.ts, linea 16 y linea 24, descomentar eso. 
Es una clausula de reject de TLS del servidor, dado que la api es https y angular es http causa conflicto.

Una vez que el conflicto en dev se mitigue, apareceran todos los registros con los teléfonos formateados.
La prueba unitaria con Jasmine está en: src/app/components/clientes/clientes.component.spec.ts
