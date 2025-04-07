
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
    id_cliente INT,
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
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
	);

-- Insertar Usuarios (Admins y Empleados para manejar productos)
GO
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

--
INSERT INTO Facturas (tipo_factura, id_cliente, id_empleado)
VALUES ('Venta', 1, 2);  -- Asegúrate de que los IDs existan en Usuarios
--
INSERT INTO Detalles_Facturas (id_factura, id_producto, cantidad)
VALUES 
(18, 3, 2);  -- Producto 3, 2 unidades a $5000

--

INSERT INTO Facturas (tipo_factura, id_cliente, id_empleado)
VALUES ('Compra', 3, 2);  -- Cliente 3 y empleado 2
--
INSERT INTO Detalles_Facturas (id_factura, id_producto, cantidad)
VALUES 
(19, 1, 10);



/*
-- Desactivar temporalmente las restricciones de claves foráneas
ALTER TABLE Facturas NOCHECK CONSTRAINT ALL;
ALTER TABLE Productos NOCHECK CONSTRAINT ALL;
ALTER TABLE Detalles_Facturas NOCHECK CONSTRAINT ALL;

-- Eliminar los registros de las tablas en orden correcto
DELETE FROM Facturas;
DELETE FROM Productos;
DELETE FROM Proveedores;
DELETE FROM Categorias;
DELETE FROM Usuarios;
DELETE FROM Detalles_Facturas;


-- Reactivar las restricciones
ALTER TABLE Facturas CHECK CONSTRAINT ALL;
ALTER TABLE Productos CHECK CONSTRAINT ALL;
ALTER TABLE Detalles_Facturas CHECK CONSTRAINT ALL;
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

/*CREATE PROCEDURE sp_ObtenerFacturasVenta
AS
BEGIN
	SELECT
		f.id_factura AS ID,
		f.id_empleado AS Empleado,
		f.id_cliente AS Cliente,
		f.fecha AS Fecha
	FROM Facturas f
	*/
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
-- GO


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


CREATE PROCEDURE sp_ObtenerFacturas
AS
BEGIN
    SELECT 
        f.id_factura AS ID,
        emp.nombre + ' ' + emp.apellido AS Empleado,

        -- Mostrar cliente solo si es una venta
        CASE 
            WHEN f.tipo_factura = 'Venta' THEN cli.nombre + ' ' + cli.apellido
            ELSE NULL
        END AS Cliente,

        -- Mostrar proveedor solo si es una compra
        CASE 
            WHEN f.tipo_factura = 'Compra' THEN prov.nombre
            ELSE NULL
        END AS Proveedor,

        f.tipo_factura AS Tipo,
		f.fecha AS Fecha,
        SUM(df.cantidad * df.precio) AS Total

    FROM Facturas f
    JOIN Usuarios emp ON f.id_empleado = emp.id_usuario
    LEFT JOIN Usuarios cli ON f.id_cliente = cli.id_usuario
    JOIN Detalles_Facturas df ON f.id_factura = df.id_factura
    JOIN Productos p ON df.id_producto = p.id_producto
    LEFT JOIN Proveedores prov ON p.id_proveedor = prov.id_proveedor 

    GROUP BY 
        f.id_factura, 
        emp.nombre, emp.apellido, 
        cli.nombre, cli.apellido, 
        prov.nombre, 
		f.fecha,
        f.tipo_factura;
END;
GO





CREATE TRIGGER trg_InsertarPrecioAutomatico
ON Detalles_Facturas
AFTER INSERT
AS
BEGIN
    UPDATE df
    SET df.precio = p.precio_venta
    FROM Detalles_Facturas df
    JOIN inserted i ON df.id_detalles = i.id_detalles
    JOIN Productos p ON i.id_producto = p.id_producto;
END;