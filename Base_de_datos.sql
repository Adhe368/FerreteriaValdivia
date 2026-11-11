-- 1. Crear y usar la base de datos limpia
DROP DATABASE IF EXISTS ferreteriavaldiviadb;
CREATE DATABASE ferreteriavaldiviadb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE ferreteriavaldiviadb;

-- 2. Tabla Categoria
CREATE TABLE Categoria (
    id_Categoria INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Categoria VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

-- 3. Tabla Proveedor
CREATE TABLE Proveedor (
    id_Proveedor INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Proveedor VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Direccion VARCHAR(150)
) ENGINE=InnoDB;

-- 4. Tabla Rol
CREATE TABLE Rol (
    id_Rol INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Rol VARCHAR(50) NOT NULL
) ENGINE=InnoDB;

-- 5. Tabla Empleado
CREATE TABLE Empleado (
    id_Empleado INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    id_Rol INT,
    FOREIGN KEY (id_Rol) REFERENCES Rol(id_Rol) ON DELETE SET NULL
) ENGINE=InnoDB;

-- 6. Tabla Usuario
CREATE TABLE Usuario (
    id_Usuario INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    id_Empleado INT,
    FOREIGN KEY (id_Empleado) REFERENCES Empleado(id_Empleado) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 7. Tabla Cliente
CREATE TABLE Cliente (
    id_Cliente INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Nit_Ci VARCHAR(20),
    Telefono VARCHAR(20)
) ENGINE=InnoDB;

-- 8. Tabla Caja
CREATE TABLE Caja (
    id_Caja INT AUTO_INCREMENT PRIMARY KEY,
    FechaApertura DATETIME NOT NULL,
    FechaCierre DATETIME NULL,
    MontoInicial DECIMAL(18,2) NOT NULL,
    MontoFinal DECIMAL(18,2) NULL,
    estado VARCHAR(50) NOT NULL DEFAULT 'Abierta',
    id_Empleado INT,
    FOREIGN KEY (id_Empleado) REFERENCES Empleado(id_Empleado) ON DELETE SET NULL
) ENGINE=InnoDB;

-- 9. Tabla Productos (con sus relaciones exactas)
CREATE TABLE Productos (
    CodigoProducto VARCHAR(50) PRIMARY KEY,
    Nombre_Producto VARCHAR(100) NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,
    StockMinimo INT NOT NULL DEFAULT 0,
    StockActual INT NOT NULL DEFAULT 0,
    CantidadVendida INT NOT NULL DEFAULT 0,
    id_Categoria INT,
    id_Proveedor INT,
    FOREIGN KEY (id_Categoria) REFERENCES Categoria(id_Categoria) ON DELETE SET NULL,
    FOREIGN KEY (id_Proveedor) REFERENCES Proveedor(id_Proveedor) ON DELETE SET NULL
) ENGINE=InnoDB;





-- ==========================================================
-- INSERT DE PRUEBA: FerreteriaValdiviaNueva
-- ==========================================================

-- 1. Categoria
INSERT INTO Categoria (id_Categoria, Nombre_Categoria) VALUES 
(1, 'Herramientas Manuales'), 
(2, 'Electricidad'), 
(3, 'Plomería');

-- 2. Proveedor
INSERT INTO Proveedor (id_Proveedor, Nombre_Proveedor, Telefono, Direccion) VALUES 
(1, 'Ferretería Mayorista S.R.L.', '22445566', 'Zona Industrial El Alto'),
(2, 'Importaciones Globales', '23112233', 'Av. 6 de Agosto');

-- 3. Rol
INSERT INTO Rol (id_Rol, Nombre_Rol) VALUES 
(1, 'Administrador'), 
(2, 'Cajero'), 
(3, 'Almacenero');

-- 4. Empleado
INSERT INTO Empleado (id_Empleado, Nombre, Apellido, Telefono, id_Rol) VALUES 
(1, 'Juan', 'Pérez', '70111222', 1),
(2, 'María', 'Gómez', '70222333', 2),
(3, 'Carlos', 'Soria', '70333444', 3);

-- 5. Usuario (Opcional, si lo usas)
INSERT INTO Usuario (id_Usuario, NombreUsuario, Contrasena, id_Empleado) VALUES 
(1, 'jperez', '123456', 1),
(2, 'mgomez', '123456', 2);

-- 6. Cliente
INSERT INTO Cliente (id_cliente, Nombre, Apellido, Nit_Ci, Telefono) VALUES 
(1, 'Carlos', 'Valdivia', '4587962', '70123456'),
(2, 'Ana', 'Pérez', '7894561', '79876543'),
(3, 'Luis', 'Gómez', '1234567', '72345678');

-- 7. Caja
INSERT INTO Caja (id_Caja, FechaApertura, FechaCierre, MontoInicial, MontoFinal, estado, id_Empleado) VALUES 
(1, '2026-11-10 08:00:00', NULL, 150.00, NULL, 'Abierta', 2),
(2, '2026-11-09 08:00:00', '2026-11-09 18:30:00', 100.00, 1250.50, 'Cerrada', 2),
(3, '2026-11-08 08:00:00', '2026-11-08 19:00:00', 200.00, 1540.00, 'Cerrada', 1);

-- 8. Productos
INSERT INTO Productos (CodigoProducto, Nombre_Producto, PrecioVenta, StockMinimo, StockActual, CantidadVendida, id_Categoria, id_Proveedor) VALUES 
('P001', 'Martillo de acero templado', 45.00, 5, 20, 3, 1, 1),
('P002', 'Cinta aislante 10m', 8.50, 10, 50, 12, 2, 2),
('P003', 'Llave ajustable 10"', 65.00, 3, 15, 2, 1, 1),
('P004', 'Tubo PVC 4 pulgadas', 35.00, 8, 30, 5, 3, 2);