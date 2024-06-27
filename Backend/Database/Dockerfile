# Utiliza la imagen base de SQL Server 2022 desde Microsoft Container Registry
FROM mcr.microsoft.com/mssql/server:latest

# Variables de entorno para aceptar la EULA y establecer la contraseña del usuario 'sa'
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=UnaContraseñaSegura123!

# Copia los archivos de inicialización personalizados, si es necesario
# COPY setup.sql /docker-entrypoint-initdb.d/

# Expone el puerto 1433 para conexiones externas
EXPOSE 1433

# Comando de inicio, no es necesario modificarlo si no se requiere una configuración adicional
CMD ["/opt/mssql/bin/sqlservr"]