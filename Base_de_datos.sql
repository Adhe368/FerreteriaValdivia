-- 1. Crear y usar la base de datos limpia
CREATE DATABASE IF NOT EXISTS ferreteriavaldiviadb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE ferreteriavaldiviadb;

CREATE TABLE ferreteriavaldiviadb.Categoria (
    id_Categoria INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Categoria VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE ferreteriavaldiviadb.Proveedor (
    id_Proveedor INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Proveedor VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Direccion VARCHAR(150)
) ENGINE=InnoDB;

CREATE TABLE ferreteriavaldiviadb.Rol (
    id_Rol INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Rol VARCHAR(50) NOT NULL
) ENGINE=InnoDB;


CREATE TABLE ferreteriavaldiviadb.Empleado (
    id_Empleado INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Correo VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    id_Rol INT,
    FOREIGN KEY (id_Rol) REFERENCES Rol(id_Rol) ON DELETE SET NULL
) ENGINE=InnoDB;


CREATE TABLE ferreteriavaldiviadb.Usuario (
    id_Usuario INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    id_Empleado INT,
    FOREIGN KEY (id_Empleado) REFERENCES Empleado(id_Empleado) ON DELETE CASCADE
) ENGINE=InnoDB;


CREATE TABLE ferreteriavaldiviadb.Cliente (
    id_Cliente INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Nit_Ci VARCHAR(20),
    Telefono VARCHAR(20)
) ENGINE=InnoDB;


CREATE TABLE ferreteriavaldiviadb.Caja (
    id_Caja INT AUTO_INCREMENT PRIMARY KEY,
    FechaApertura DATETIME NOT NULL,
    FechaCierre DATETIME NULL,
    MontoInicial DECIMAL(18,2) NOT NULL,
    MontoFinal DECIMAL(18,2) NULL,
    estado VARCHAR(50) NOT NULL DEFAULT 'Abierta',
    id_Empleado INT,
    FOREIGN KEY (id_Empleado) REFERENCES Empleado(id_Empleado) ON DELETE SET NULL
) ENGINE=InnoDB;


CREATE TABLE ferreteriavaldiviadb.Productos (
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


-- ==========================================
-- 10. INSERCIÓN DE DATOS REALES (10 registros c/u)
-- ==========================================


INSERT INTO ferreteriavaldiviadb.Rol (id_Rol, Nombre_Rol) VALUES 
(1, 'Administrador General'),
(2, 'Encargado de Almacén'),
(3, 'Vendedor de Mostrador'),
(4, 'Supervisor de Caja');


INSERT INTO ferreteriavaldiviadb.Empleado (id_Empleado, Nombre, Apellido, Telefono, Correo, Password, id_Rol) VALUES
(1, 'Rodrigo', 'Valdivia Mamani', '71548962', 'rodrigo.valdivia@ferreteria.com', '123', 1),
(2, 'Alejandra', 'Salazar Flores', '72596314', 'alejandra.salazar@ferreteria.com', '123', 2),
(3, 'Mauricio', 'Ticona Quispe', '73812546', 'mauricio.ticona@ferreteria.com', '123', 3),
(4, 'Carla', 'Mendoza Rivero', '70125896', 'carla.mendoza@ferreteria.com', '123', 3),
(5, 'Gonzalo', 'Paredes Choque', '79632147', 'gonzalo.paredes@ferreteria.com', '123', 4),
(6, 'Valeria', 'Hinojosa Soria', '78965412', 'valeria.hinojosa@ferreteria.com', '123', 2),
(7, 'Diego', 'Villarroel Cuentas', '77412589', 'diego.villarroel@ferreteria.com', '123', 3),
(8, 'Jimena', 'Fernández Vargas', '76321458', 'jimena.fernandez@ferreteria.com', '123', 3),
(9, 'Esteban', 'Arze Melendres', '75236987', 'esteban.arze@ferreteria.com', '123', 2),
(10, 'Lucia', 'Montaño Bustillos', '71485236', 'lucia.montano@ferreteria.com', '123', 4);


INSERT INTO ferreteriavaldiviadb.Categoria (id_Categoria, Nombre_Categoria) VALUES
(1, 'Herramientas Manuales'),
(2, 'Herramientas Eléctricas'),
(3, 'Pinturas y Solventes'),
(4, 'Plomería y Grifería'),
(5, 'Electricidad e Iluminación'),
(6, 'Materiales de Construcción'),
(7, 'Cerrajería y Seguridad'),
(8, 'Tornillería y Fijaciones'),
(9, 'Jardinería y Riego'),
(10, 'Equipos de Protección (EPP)');


INSERT INTO ferreteriavaldiviadb.Proveedor (id_Proveedor, Nombre_Proveedor, Telefono, Direccion) VALUES
(1, 'Ferretera Industrial Andina S.R.L.', '22456789', 'Av. 6 de Agosto #2400'),
(2, 'Importadora Metalmecánica Bolivia', '23123456', 'Calle Comercio #500'),
(3, 'Pinturas Soboce & Cía.', '24233445', 'El Alto, Zona Industrial'),
(4, 'Casa de la Tornillería El Tunari', '21255667', 'Av. Buenos Aires #1200'),
(5, 'Comercializadora Eléctrica Illimani', '22277889', 'Calle Murillo #315'),
(6, 'Tubos y Conexiones Plasticor', '28399001', 'Zona Achachicala #80'),
(7, 'Distribuidora de Aceros ACI', '23711223', 'Carretera a Viacha Km 4'),
(8, 'Seguridad Industrial Total S.A.', '24133445', 'El Prado #1450'),
(9, 'Herramientas y Maquinaria Bosch Bolivia', '27955667', 'Av. Montenegro, San Miguel'),
(10, 'Importadora San José de Materiales', '22088990', 'Zona Villa Fátima #400');


INSERT INTO ferreteriavaldiviadb.Cliente (id_Cliente, Nombre, Apellido, Nit_Ci, Telefono) VALUES
(1, 'Marcelo', 'Justiniano Prado', '4851230', '70711223'),
(2, 'Beatriz', 'Ovando Montenegro', '6123489', '71822334'),
(3, 'Renán', 'Calderón Luna', '3987124', '72933445'),
(4, 'Silvia', 'Delgadillo Céspedes', '7012356', '73044556'),
(5, 'Hernán', 'Borda Sotomayor', '2145896', '74155667'),
(6, 'Patricia', 'Urey Zambrana', '5236987', '75266778'),
(7, 'Gustavo', 'Espinoza Roca', '6891234', '76377889'),
(8, 'Paola', 'Navia Melgar', '4123789', '77488990'),
(9, 'Javier', 'Saavedra Cuéllar', '5896321', '78599001'),
(10, 'Claudia', 'Peñaranda Ribera', '3145678', '79600112');


INSERT INTO ferreteriavaldiviadb.Caja (id_Caja, FechaApertura, MontoInicial, estado, id_Empleado) VALUES
(1, '2026-11-11 08:00:00', 1000.00, 'Abierta', 1);


INSERT INTO ferreteriavaldiviadb.Productos (CodigoProducto, Nombre_Producto, PrecioVenta, StockMinimo, StockActual, CantidadVendida, id_Categoria, id_Proveedor) VALUES
('PROD-001', 'Taladro Percutor Inalámbrico 18V', 650.00, 5, 25, 12, 2, 9),
('PROD-002', 'Juego de Llaves Combinadas x 12 pzas', 180.00, 10, 40, 18, 1, 1),
('PROD-003', 'Pintura Látex Blanco Interior 20L', 280.00, 8, 30, 22, 3, 3),
('PROD-004', 'Inodoro Cerámico Completo Tradicional', 520.00, 3, 12, 5, 4, 6),
('PROD-005', 'Rollo de Cable Mellizo Nro. 12 (100m)', 350.00, 5, 15, 9, 5, 5),
('PROD-006', 'Bolsa de Cemento IP-40 (50kg)', 55.00, 20, 150, 85, 6, 10),
('PROD-007', 'Cerradura de Sobreponer para Puerta', 120.00, 6, 20, 14, 7, 2),
('PROD-008', 'Caja de Tornillos Autorroscantes (100u)', 45.00, 15, 60, 30, 8, 4),
('PROD-009', 'Manguera de Riego Reforzada 1/2 pulg (50m)', 160.00, 4, 18, 7, 9, 6),
('PROD-010', 'Casco de Seguridad Industrial c/ Arnés', 65.00, 10, 35, 19, 10, 8);

