
# MercApp - Sistema de Gesti�n de Peque�os Negocios y Tiendas Locales

## Descripci�n del Proyecto
MercApp es una API dise�ada para gestionar los aspectos m�s importantes de peque�os negocios y tiendas locales en El Salvador. La Weh api ofrece una soluci�n integral para la administraci�n de inventario, ventas, clientes y an�lisis de negocio, adaptada a las necesidades espec�ficas del mercado salvadore�o. Incluye funcionalidades avanzadas, como soporte para multimoneda (d�lares y bitc�in), emisi�n de facturas electr�nicas y generaci�n autom�tica de pedidos a proveedores.

## Caracter�sticas
- **Gesti�n de Inventario:** CRUD para productos, control de stock, alertas por bajo inventario, y generaci�n autom�tica de pedidos a proveedores.
- **Control de Ventas:** Registro de ventas, emisi�n de facturas electr�nicas y control de caja.
- **An�lisis de Ventas:** Reportes detallados que muestran los productos m�s vendidos, an�lisis de ventas por hora y categor�as.
- **M�dulo de Clientes:** Creaci�n de perfiles para clientes frecuentes, seguimiento de su historial de compras, y aplicaci�n de promociones y descuentos.
- **Multimoneda:** Gesti�n de transacciones en d�lares y bitc�in, adaptando la API a las tendencias financieras actuales de El Salvador.

## Requisitos Previos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado en tu sistema.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) instalado y en ejecuci�n.
- [Node.js](https://nodejs.org/) instalado para la configuraci�n de TailwindCSS.
- Visual Studio Code o Visual Studio como entorno de desarrollo.

## Configuraci�n Inicial del Proyecto

### 1. Crear el Proyecto ASP.NET Core
Creamos el proyecto utilizando el siguiente comando:
```bash
dotnet new webapp -n MercApp
```

### 2. Configuraci�n de la Cadena de Conexi�n
En el archivo `appsettings.json`, agregamos la cadena de conexi�n para conectarnos a SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=DESKTOP-T97E6M3;Initial Catalog=MercApp;Integrated Security=True;TrustServerCertificate=True"
}
```

### 3. Instalaci�n de Paquetes NuGet
Instalamos los paquetes necesarios para trabajar con Entity Framework Core y SQL Server:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 4. Configuraci�n de Entity Framework Core
Creamos el contexto `AppDbContext` y las clases de modelo (`Usuario`, `Genero`, `Rol`, etc.) en el proyecto dentro de las carpetas `Data` y `Models`.

### 5. Crear la Primera Migraci�n
Para crear la migraci�n inicial que define el esquema de la base de datos, ejecutamos el siguiente comando:
```bash
dotnet ef migrations add "PrimeraMigracion"
```

### 6. Aplicar la Migraci�n a la Base de Datos
Para aplicar la migraci�n y crear las tablas en la base de datos, ejecutamos:
```bash
dotnet ef database update
```

### Paso 3: Ejecutar el comando de migración en Visual Studio Code
Abre la terminal en Visual Studio Code (puedes abrirla con `Ctrl + \``) y ejecuta el comando para agregar la nueva migración:

```bash
dotnet ef migrations add UpdatePasswordFieldLength
```
Luego, aplica la migración ejecutando:
```bash
dotnet ef database update
```
### Paso 4: Ejecutar el comando de migración en Visual Studio
Abre la "Consola del Administrador de Paquetes" (Tools > NuGet Package Manager > Package Manager Console).
En la consola, ejecuta:
```powershell
Copiar código
Add-Migration UpdatePasswordFieldLength
```
Luego, para aplicar la migración, ejecuta:
```powershell
Copiar código
Update-Database
```


## Configuraci�n de TailwindCSS
TailwindCSS fue configurado para el proyecto utilizando Node.js y npm:

### 1. Inicializar el Proyecto con npm
```bash
npm init -y
```

### 2. Instalar TailwindCSS
```bash
npm install tailwindcss
```

### 3. Crear el Archivo de Configuraci�n de TailwindCSS
Creamos el archivo `tailwind.config.js` con el siguiente comando:
```bash
npx tailwindcss init
```

### 4. Configurar TailwindCSS
En el archivo `tailwind.config.js`, especificamos las rutas de los archivos donde TailwindCSS debe buscar las clases utilizadas:
```js
module.exports = {
  content: [
    './wwwroot/**/*.html',
    './Views/**/*.cshtml'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

### 5. Crear el Archivo CSS de Tailwind
Creamos un archivo CSS (`site.css`) e importamos las directivas de TailwindCSS:
```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

### 6. Compilar el CSS de Tailwind
Compilamos el CSS de Tailwind para incluirlo en el proyecto:
```bash
npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/output.css --watch
```

## Ejecuci�n del Proyecto
Para ejecutar el proyecto desde la terminal en Visual Studio Code, utilizamos el siguiente comando:
```bash
dotnet run
```
Esto iniciar� el servidor de desarrollo y el proyecto ser� accesible en `https://localhost:5001` o `http://localhost:5000`.

## Instrucciones para Insertar Datos Iniciales
Despu�s de aplicar las migraciones, podemos insertar manualmente los datos iniciales en las tablas de `Generos` y `Roles` utilizando los siguientes scripts SQL en SQL Server Management Studio (SSMS):
```sql
INSERT INTO Generos (Nombre)
VALUES ('Masculino'), ('Femenino');

INSERT INTO Roles (Nombre)
VALUES ('Administrador'), ('Cliente');
```

## Comandos �tiles
- **Crear una nueva migraci�n:**
  ```bash
  dotnet ef migrations add "NombreDeLaMigracion"
  ```
- **Actualizar la base de datos con las migraciones:**
  ```bash
  dotnet ef database update
  ```
- **Limpiar el proyecto:**
  ```bash
  dotnet clean
  ```
- **Construir el proyecto:**
  ```bash
  dotnet build
  ```

## Estructura del Proyecto
- `Controllers/`: Contiene los controladores de la aplicaci�n.
- `Data/`: Incluye la clase `AppDbContext` para la configuraci�n de Entity Framework Core.
- `Migrations/`: Almacena las migraciones generadas por Entity Framework Core.
- `Models/`: Define las clases de modelo (`Usuario`, `Genero`, `Rol`, etc.).
- `Views/`: Contiene las vistas para la interfaz de usuario.
- `wwwroot/`: Directorio para archivos est�ticos como CSS, JavaScript e im�genes.

## Recursos Adicionales
- [Documentaci�n de Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Documentaci�n de TailwindCSS](https://tailwindcss.com/docs)
- [Documentación de TailwindCSS](https://tailwindcss.com/docs)
