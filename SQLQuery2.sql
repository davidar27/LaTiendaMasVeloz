
-- Crear la base de datos
CREATE DATABASE LaTiendaMasVeloz;
GO

-- Usar la base de datos
USE LaTiendaMasVeloz;
GO


-- Crear la tabla de Usuarios
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    contraseña VARCHAR(255) NOT NULL,
    rol VARCHAR(30) CHECK (rol IN ('Administrador', 'Empleado', 'Cliente')) NOT NULL
);
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
    nombre VARCHAR(100) NOT NULL UNIQUE, -- Evita nombres duplicados
    descripcion TEXT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria) ON DELETE CASCADE,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor) ON DELETE CASCADE
);
GO



-- Crear la tabla de Ventas
CREATE TABLE Ventas (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario) ON DELETE CASCADE
);
GO

-- Crear la tabla de Detalle_Ventas
CREATE TABLE Detalle_Ventas (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL UNIQUE,
    id_producto INT NOT NULL UNIQUE,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED,
    FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO

-- Crear la tabla de Compras
CREATE TABLE Compras (
    id_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor) ON DELETE CASCADE
);
GO

-- Crear la tabla de Detalle_Compras
CREATE TABLE Detalle_Compras (
    id_detalle_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_compra INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED,
    FOREIGN KEY (id_compra) REFERENCES Compras(id_compra) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO

ALTER TABLE Detalle_Compras 
ADD CONSTRAINT UQ_Compra_Producto UNIQUE (id_compra, id_producto);


-- Crear la tabla Facturas
CREATE TABLE Facturas (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    tipo_factura VARCHAR(10) CHECK (tipo_factura IN ('Venta', 'Compra')) NOT NULL,
    id_venta INT NULL,
    id_compra INT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    subtotal DECIMAL(10,2) NOT NULL,
    impuestos DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    id_cliente INT NULL,
    id_proveedor INT NULL,

    -- Claves foráneas SIN `ON DELETE SET NULL`
    FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta),
    FOREIGN KEY (id_compra) REFERENCES Compras(id_compra),
    FOREIGN KEY (id_cliente) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);
GO





-- Insertar Usuarios (Admins y Empleados para manejar productos)
INSERT INTO Usuarios (nombre, apellido, contraseña, rol) VALUES 
('Juan', 'Pérez', 'admin123', 'Administrador'),
('Maria', 'Gonzalez', 'empleado456', 'Empleado'),
('Carlos', 'Ramirez', 'cliente789', 'Cliente'),
('Ana', 'Lopez', 'admin555', 'Administrador'),
('Luis', 'Torres', 'empleado666', 'Empleado');

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


-- Insertar Compras (Para tener stock)
INSERT INTO Compras (id_proveedor, fecha, total) VALUES 
(1, GETDATE(), 3000.00), 
(2, GETDATE(), 1500.00), 
(3, GETDATE(), 800.00);

-- Insertar Detalle de Compras (Para relacionar productos con proveedores)
INSERT INTO Detalle_Compras (id_compra, id_producto, cantidad, precio_unitario) VALUES 
(1, 1, 5, 1500.00), -- Bicicleta de Montaña
(1, 2, 2, 1800.00), -- Bicicleta de Ruta
(2, 3, 10, 120.00) -- Casco de Protección

/*
-- Desactivar temporalmente las restricciones de claves foráneas
ALTER TABLE Facturas NOCHECK CONSTRAINT ALL;
ALTER TABLE Detalle_Ventas NOCHECK CONSTRAINT ALL;
ALTER TABLE Detalle_Compras NOCHECK CONSTRAINT ALL;
ALTER TABLE Ventas NOCHECK CONSTRAINT ALL;
ALTER TABLE Compras NOCHECK CONSTRAINT ALL;
ALTER TABLE Productos NOCHECK CONSTRAINT ALL;

-- Eliminar los registros de las tablas en orden correcto
DELETE FROM Detalle_Ventas;
DELETE FROM Detalle_Compras;
DELETE FROM Facturas;
DELETE FROM Ventas;
DELETE FROM Compras;
DELETE FROM Productos;
DELETE FROM Proveedores;
DELETE FROM Categorias;
DELETE FROM Usuarios;

-- Reactivar las restricciones
ALTER TABLE Facturas CHECK CONSTRAINT ALL;
ALTER TABLE Detalle_Ventas CHECK CONSTRAINT ALL;
ALTER TABLE Detalle_Compras CHECK CONSTRAINT ALL;
ALTER TABLE Ventas CHECK CONSTRAINT ALL;
ALTER TABLE Compras CHECK CONSTRAINT ALL;
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
        pr.nombre AS Proveedor 
    FROM Productos p
    INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
    INNER JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor;
END;
GO

EXEC sp_ObtenerProductos;

GO


DELETE FROM Productos WHERE nombre = 'dawd';

-- sp_AgregarProducto --
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
END;
GO

EXEC sp_AgregarProducto
    @nombre = 'Bicicleta de Ruta2222',
    @categoria = 'Bicicletas',
    @descripcion = 'Bicicleta ligera para carreras de ruta',
    @precio = 1500.75,
    @stock = 5,
    @proveedor = 'BikeWorld';





	--

	CREATE PROCEDURE sp_ActualizarProducto
    @nombre_producto NVARCHAR(255),
    @nueva_descripcion NVARCHAR(500),
    @nuevo_precio DECIMAL(10,2),
    @nuevo_stock INT,
    @nueva_categoria NVARCHAR(255),
    @nuevo_proveedor NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @id_categoria INT, @id_proveedor INT, @id_producto INT;

    -- Obtener el ID del producto
    SELECT @id_producto = id_producto FROM Productos WHERE nombre = @nombre_producto;

    IF @id_producto IS NULL
    BEGIN
        RAISERROR('El producto especificado no existe.', 16, 1);
        RETURN;
    END

    -- Obtener el ID de la categoría
    SELECT @id_categoria = id_categoria FROM Categorias WHERE nombre = @nueva_categoria;

    IF @id_categoria IS NULL
    BEGIN
        RAISERROR('La categoría especificada no existe.', 16, 1);
        RETURN;
    END

    -- Obtener el ID del proveedor
    SELECT @id_proveedor = id_proveedor FROM Proveedores WHERE nombre = @nuevo_proveedor;

    IF @id_proveedor IS NULL
    BEGIN
        RAISERROR('El proveedor especificado no existe.', 16, 1);
        RETURN;
    END

    -- Actualizar el producto
    UPDATE Productos
    SET 
        descripcion = @nueva_descripcion,
        precio_venta = @nuevo_precio,
        stock = @nuevo_stock,
        id_categoria = @id_categoria,
        id_proveedor = @id_proveedor
    WHERE id_producto = @id_producto;
    
    PRINT 'Producto actualizado correctamente.';
END;
GO



----
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

EXEC sp_ActualizarProducto 
    @id_producto = 1,
    @nombre = 'Bicicleta de PPP',
    @categoria = 'Bicicletas',
    @descripcion = 'Bicicleta ideal para terrenos difíciles.',
    @precio = 250.99,
    @stock = 15,
    @proveedor = 'BikeWorld';
