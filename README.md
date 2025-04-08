# Prueba Técnica - Gestión de Productos - Control Online International

## 📦 Tecnologías usadas
- Lenguaje: C#
- Backend: .NET 8
- Base de datos: SQL Server (docker entorno de desarrollo)
- Frontend: HTML, CSS, JavaScript
- Arquitectura: MVC y API REST

---

## ▶️ Cómo ejecutar el proyecto

### 🐳 docker-compose para desarrollo (WARNING)

Dado que se está en un entorno de pruebas, el contenedor corre con el usuario sa solo para facilitar el desarrollo.

En producción, se debe crear un usuario específico con permisos mínimos.

Estructura de archivos docker folder:

Dockerfile - Configuración del contenedor
entrypoint.sh - Script de punto de entrada
configure-db.sh - Script para verificar la base de datos y ejecutar scripts SQL
setup.sql - Script SQL para crear base de datos
docker-compose.yml - Configuración de Docker Compose

### Construir y ejecutar el contenedor
```bash
docker-compose up
```
También puedes usar la opción -d para ejecutar en segundo plano:
```bash
docker-compose up -d
```

### Verificar la instalación
Una vez que veas el mensaje "Configuration completed" en los logs, tu base de datos está lista para usar.

### Backend (API)
1. **Requisitos:**
   - Tener instalado [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
   - Tener SQL Server instalado y corriendo.

2. **Pasos:**
   - Clona el repositorio.
   - Dentro del folder CoiServiceCrud ejecuta
      ```bash
      dotnet restore
      dotnet build
      dotnet run
      ```

   [- Abre el proyecto en Visual Studio 2022+ o VS Code con las respectivas extensiones de C#.]: #

   [- Configura la cadena de conexión a tu SQL Server en `appsettings.json`.]: #
   [# - Ejecuta las migraciones para crear la base de datos (si usas Entity Framework).]: #
   [#- Presiona `F5` o usa `dotnet run` para iniciar la API.]: #

