# 🛠️ Ferretería Valdivia - Sistema de Gestión

Sistema web desarrollado en **ASP.NET Core MVC** con Entity Framework Core y C#, diseñado para la gestión integral de inventario, proveedores, clientes, empleados, roles, cajas y paneles estadísticos modulares.

---

## 📋 Requisitos Previos

Asegúrate de tener instalado en tu entorno de desarrollo:
- [.NET SDK](https://dotnet.microsoft.com/download) (versión compatible con el proyecto, ej. .NET 6 o superior).
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/).
- Un servidor de base de datos compatible (como **MySQL** o **MariaDB**).
- Usar puerto 3306.


---

## ⚙️ Configuración y Puesta en Marcha

### 1. Clonar o descargar el repositorio
Abre tu terminal en la carpeta del proyecto.

### 2. Configurar la Base de Datos
El proyecto incluye un respaldo SQL para inicializar la estructura y datos necesarios:
1. Ubica el archivo **`Base_de_datos.sql`** en la raíz o carpeta del proyecto.
2. Importa este archivo en tu servidor MySQL / MariaDB utilizando tu gestor preferido (como *phpMyAdmin*, *HeidiSQL* o la consola de MySQL):
   ```sql
   CREATE DATABASE FerreteriaValdiviaNueva;
   -- Luego importa el contenido del archivo Base_de_datos.sql en esta base de datos.