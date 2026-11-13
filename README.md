# 🛠️ Ferretería Valdivia - Sistema de Gestión

Sistema web desarrollado en **ASP.NET Core MVC** con Entity Framework Core y C#, diseñado para la gestión integral de inventario, proveedores, clientes, empleados, roles, cajas y paneles estadísticos modulares.

---

## 📋 Requisitos Previos

Asegúrate de tener instalado en tu entorno de desarrollo:
- [.NET SDK](https://dotnet.microsoft.com/download) (.NET 9).
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/).
- Un servidor de base de datos como **MySQL** o **MariaDB**.

---

## ⚙️ Configuración y Puesta en Marcha

### 1. Clonar o descargar el repositorio
Abre tu terminal en la carpeta del proyecto.

### 2. Configurar la Base de Datos
El proyecto incluye un respaldo SQL para inicializar la estructura y datos necesarios:
1. Importa el archivo **`Base_de_datos.sql`** que esta en la raíz del proyecto en tu servidor de base de datos MySQL / MariaDB
2. Correr la aplicacion
```
dotnet run
```