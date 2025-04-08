# Prueba Técnica - Gestión de Productos - Control Online International

## 📦 Tecnologías usadas
- Lenguaje: C#
- Backend: .NET 8
- Base de datos: SQL Server (docker entorno de desarrollo)
- Frontend: HTML, CSS, JavaScript
- Arquitectura: MVC y API REST

---

## ▶️ Cómo ejecutar el proyecto

### Backend (API)
1. **Requisitos:**
   - Tener instalado [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
   - Tener SQL Server instalado y corriendo.

2. **Pasos:**
   - Clona el repositorio.
   - Abre el proyecto en Visual Studio 2022+ o VS Code con las respectivas extensiones de C#.

   [- Configura la cadena de conexión a tu SQL Server en `appsettings.json`.]: #
   [# - Ejecuta las migraciones para crear la base de datos (si usas Entity Framework).]: #
   [#- Presiona `F5` o usa `dotnet run` para iniciar la API.]: #

```bash
dotnet restore
dotnet build
dotnet run
```

### 🐳 docker-compose (WARNING)

Dado que se está en un entorno de pruebas, el contenedor corre con el usuario sa solo para facilitar el desarrollo.

En producción, se debe crear un usuario específico con permisos mínimos.