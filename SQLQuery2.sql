
-- Crear la base de datos
CREATE DATABASE LaTiendaMasVeloz;
GO

-- Usar la base de datos
USE LaTiendaMasVeloz;
GO


-- Crear la tabla de Usuarios
CREATE TABLE Usuarios(
	id_usuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NULL,
	correo VARCHAR(255) NOT NULL UNIQUE,
	contraseña VARCHAR(255) NOT NULL,
	rol VARCHAR(30) NOT NULL CHECK ([rol] IN ('Cliente', 'Empleado', 'Administrador'))
)
GO


-- Crear la tabla de Categorías
CREATE TABLE Categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL
);
GO

-- Crear la tabla de Proveedores
CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    contacto VARCHAR(100),
    telefono VARCHAR(20),
    direccion VARCHAR(255) NULL
);
GO

-- Crear la tabla de Productos
CREATE TABLE Productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    id_categoria INT NOT NULL,
    id_proveedor INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
	fecha DATETIME DEFAULT GETDATE()
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria) ON DELETE CASCADE,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor) ON DELETE CASCADE
);
GO



-- Crear la tabla Facturas
CREATE TABLE Facturas (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    tipo_factura VARCHAR(10) CHECK (tipo_factura IN ('Venta', 'Compra')) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    subtotal DECIMAL(10,2) NOT NULL,
    impuestos DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    id_cliente INT NULL,
	id_empleado INT,

    FOREIGN KEY (id_cliente) REFERENCES Usuarios(id_usuario),
	FOREIGN KEY (id_empleado) REFERENCES Usuarios(id_usuario)
);
GO




CREATE TABLE Detalles_Facturas(
	id_detalles  INT IDENTITY(1,1) PRIMARY KEY,
	id_factura INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	precio DECIMAL(10,2),

	FOREIGN KEY (id_factura) REFERENCES Facturas(id_factura),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),

GO
-- Insertar Usuarios (Admins y Empleados para manejar productos)
INSERT INTO Usuarios (correo, nombre, apellido, contraseña, rol) VALUES
('admin123@gmail.com', 'Juan', 'Pérez', 'admin123', 'Administrador'),
('maria456@gmail.com', 'Maria', 'Gonzalez', 'empleado456', 'Empleado'),
('carlos789@gmail.com', 'Carlos', 'Ramirez', 'cliente789', 'Cliente'),
('ana555@gmail.com', 'Ana', 'Lopez', 'admin555', 'Administrador'),
('luis666@gmail.com', 'Luis', 'Torres', 'empleado666', 'Empleado');


-- Insertar Categorías
INSERT INTO Categorias (nombre, descripcion) VALUES 
('Bicicletas', 'Bicicletas de diferentes tipos y marcas'),
('Accesorios', 'Accesorios para ciclistas'),
('Repuestos', 'Repuestos para bicicletas');

-- Insertar Proveedores
INSERT INTO Proveedores (nombre, contacto, telefono, direccion) VALUES 
('CicloShop', 'Pedro Martinez', '3001234567', 'Calle 10 #15-20, Bogotá'),
('BikeWorld', 'Laura Castro', '3117896541', 'Av. Principal #45-12, Medellín'),
('SpeedRiders', 'Jose Alvarez', '3204569871', 'Cra 50 #30-40, Cali');


-- Insertar Productos (Relacionados con Categorías y Proveedores)
INSERT INTO Productos (id_categoria, id_proveedor, nombre, descripcion, precio_venta, stock)
VALUES 
(1, 1, 'Bicicleta Montañera', 'Bicicleta para terrenos difíciles', 1500.00, 10),
(2, 2, 'Casco de seguridad', 'Casco de alta resistencia', 120.50, 20),
(3, 1, 'Guantes deportivos', 'Guantes acolchados para ciclismo', 35.00, 30);



/*
-- Desactivar temporalmente las restricciones de claves foráneas
ALTER TABLE Facturas NOCHECK CONSTRAINT ALL;
ALTER TABLE Productos NOCHECK CONSTRAINT ALL;

-- Eliminar los registros de las tablas en orden correcto
DELETE FROM Facturas;
DELETE FROM Productos;
DELETE FROM Proveedores;
DELETE FROM Categorias;
DELETE FROM Usuarios;

-- Reactivar las restricciones
ALTER TABLE Facturas CHECK CONSTRAINT ALL;
ALTER TABLE Productos CHECK CONSTRAINT ALL;
*/

GO

CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SELECT 
		p.id_producto AS ID,
        p.nombre AS Nombre,
        c.nombre AS Categoria, 
		p.descripcion AS Descripcion,
		p.precio_venta AS Precio,
		p.stock AS Stock,
        pr.nombre AS Proveedor ,
		p.fecha AS Fecha
    FROM Productos p
    INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
    INNER JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor;
END;
GO

--
CREATE PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SELECT 
		u.id_usuario AS ID,
        u.nombre AS Nombre,
		u.apellido AS Apellido,
		u.contraseña AS Contraseña,
		u.correo AS Correo,
		u.rol AS Rol
    FROM Usuarios u
END;
GO


--
CREATE PROCEDURE sp_AgregarProducto
    @nombre NVARCHAR(100),
    @categoria NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @precio DECIMAL(10,2),
    @stock INT,
    @proveedor NVARCHAR(100)
AS
BEGIN
    DECLARE @id_categoria INT, @id_proveedor INT;
    
    -- Obtener el ID de la categoría
    SELECT @id_categoria = id_categoria FROM Categorias WHERE nombre = @categoria;
    
    -- Obtener el ID del proveedor
    SELECT @id_proveedor = id_proveedor FROM Proveedores WHERE nombre = @proveedor;

    -- Verificar que existan la categoría y el proveedor
    IF @id_categoria IS NULL
    BEGIN
        PRINT 'Error: La categoría no existe.';
        RETURN;
    END

    IF @id_proveedor IS NULL
    BEGIN
        PRINT 'Error: El proveedor no existe.';
        RETURN;
    END

    -- Insertar el producto
    INSERT INTO Productos (nombre, id_categoria, descripcion, precio_venta, stock, id_proveedor)
    VALUES (@nombre, @id_categoria, @descripcion, @precio, @stock, @id_proveedor);

    PRINT 'Producto agregado correctamente.';
END;
GO

CREATE PROCEDURE sp_AgregarUsuario
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @correo NVARCHAR(100),
    @contraseña NVARCHAR(255),
    @rol NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Usuarios (nombre, apellido, correo, contraseña, rol)
    VALUES (@nombre, @apellido, @correo, @contraseña, @rol);

    PRINT 'Usuario agregado correctamente';
END;
GO

--

 CREATE PROCEDURE sp_ActualizarProducto
    @id_producto INT, 
    @nombre NVARCHAR(100),
    @categoria NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @precio DECIMAL(10,2),
    @stock INT,
    @proveedor NVARCHAR(100)
AS
BEGIN
    DECLARE @id_categoria INT, @id_proveedor INT;
    
    -- Obtener el ID de la categoría
    SELECT @id_categoria = id_categoria FROM Categorias WHERE nombre = @categoria;
    
    -- Obtener el ID del proveedor
    SELECT @id_proveedor = id_proveedor FROM Proveedores WHERE nombre = @proveedor;

    -- Verificar que existan la categoría y el proveedor
    IF @id_categoria IS NULL
    BEGIN
        PRINT 'Error: La categoría no existe.';
        RETURN;
    END

    IF @id_proveedor IS NULL
    BEGIN
        PRINT 'Error: El proveedor no existe.';
        RETURN;
    END

    -- Verificar que el producto existe
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE id_producto = @id_producto)
    BEGIN
        PRINT 'Error: El producto no existe.';
        RETURN;
    END

    -- Actualizar el producto
    UPDATE Productos
    SET 
        nombre = @nombre,
        id_categoria = @id_categoria,
        descripcion = @descripcion,
        precio_venta = @precio,
        stock = @stock,
        id_proveedor = @id_proveedor
    WHERE id_producto = @id_producto; 

    PRINT 'Producto actualizado correctamente.';
END;
GO

CREATE PROCEDURE sp_ActualizarUsuario
    @id_usuario INT,
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @correo NVARCHAR(100),
    @contraseña NVARCHAR(255),
    @rol NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuarios
    SET 
        nombre = @nombre,
        apellido = @apellido,
        correo = @correo,
        contraseña = @contraseña,
        rol = @rol
    WHERE id_usuario = @id_usuario;

    PRINT 'Usuario actualizado correctamente';
END;
GO


