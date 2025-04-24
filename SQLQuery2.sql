
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
	contraseña VARCHAR(255)NULL,
	rol VARCHAR(30) NOT NULL CHECK ([rol] IN ('Cliente', 'Empleado', 'Administrador'))
)
GO


-- Crear la tabla de Categorías
CREATE TABLE Categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL ,
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
    id_categoria INT NULL CONSTRAINT DF_Categorias_id DEFAULT 1,
    id_proveedor INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
	fecha DATETIME DEFAULT GETDATE()
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor) ON DELETE CASCADE ON UPDATE CASCADE
);
GO




-- Crear la tabla Facturas
CREATE TABLE Facturas (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    tipo_factura VARCHAR(10) CHECK (tipo_factura IN ('Venta', 'Compra')) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    id_cliente INT,
    id_empleado INT,
    FOREIGN KEY (id_cliente) REFERENCES Usuarios(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (id_empleado) REFERENCES Usuarios(id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO





CREATE TABLE Detalles_Facturas(
	id_detalles  INT IDENTITY(1,1) PRIMARY KEY,
	id_factura INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	precio DECIMAL(10,2),

	FOREIGN KEY (id_factura) REFERENCES Facturas(id_factura)ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)ON DELETE CASCADE ON UPDATE CASCADE
	);
GO


-- Insertar Usuarios (Admins, Empleados y Clientes)
INSERT INTO Usuarios (correo, nombre, apellido, contraseña, rol) VALUES
('Existe@gmail.com', 'Existe', 'Existe', 'Existe', 'Empleado'),
('admin123@gmail.com', 'Juan', 'Pérez', 'admin123', 'Administrador'),
('maria456@gmail.com', 'Maria', 'Gonzalez', 'empleado456', 'Empleado'),
('carlos789@gmail.com', 'Carlos', 'Ramirez', 'cliente789', 'Cliente'),
('ana555@gmail.com', 'Ana', 'Lopez', 'admin555', 'Administrador'),
('luis666@gmail.com', 'Luis', 'Torres', 'empleado666', 'Empleado'),
('pedro777@gmail.com', 'Pedro', 'Rodriguez', 'cliente777', 'Cliente'),
('sofia888@gmail.com', 'Sofia', 'Fernandez', 'admin888', 'Administrador'),
('roberto999@gmail.com', 'Roberto', 'Martinez', 'empleado999', 'Empleado'),
('laura111@gmail.com', 'Laura', 'Gomez', 'cliente111', 'Cliente'),
('diego222@gmail.com', 'Diego', 'Hernandez', 'empleado222', 'Empleado'),
('valentina333@gmail.com', 'Valentina', 'Diaz', 'cliente333', 'Cliente'),
('javier444@gmail.com', 'Javier', 'Gutierrez', 'admin444', 'Administrador'),
('camila123@gmail.com', 'Camila', 'Soto', 'cliente123', 'Cliente'),
('fernando456@gmail.com', 'Fernando', 'Vargas', 'empleado456', 'Empleado'),
('natalia789@gmail.com', 'Natalia', 'Ruiz', 'cliente789', 'Cliente');


-- Insertar Categorías
INSERT INTO Categorias (nombre, descripcion) VALUES 
('Sin Categoria', 'Para productos sin categoria definida'),
('Bicicletas', 'Bicicletas de diferentes tipos y marcas'),
('Accesorios', 'Accesorios para ciclistas'),
('Repuestos', 'Repuestos para bicicletas'),
('Indumentaria', 'Ropa especializada para ciclismo'),
('Electrónica', 'Dispositivos electrónicos para ciclistas'),
('Herramientas', 'Herramientas para mantenimiento y reparación'),
('Lubricantes', 'Aceites y grasas para mantenimiento'),
('Iluminación', 'Luces y sistemas de iluminación para bicicletas'),
('Nutrición', 'Productos energéticos y suplementos para ciclistas'),
('Componentes', 'Piezas y componentes de bicicleta'),
('Seguridad', 'Elementos para protección del ciclista'),
('Entrenamiento', 'Equipos para entrenamiento y rendimiento');

-- Insertar Proveedores
INSERT INTO Proveedores (nombre, contacto, telefono, direccion) VALUES 
('CicloShop', 'Pedro Martinez', '3001234567', 'Calle 10 #15-20, Bogotá'),
('BikeWorld', 'Laura Castro', '3117896541', 'Av. Principal #45-12, Medellín'),
('SpeedRiders', 'Jose Alvarez', '3204569871', 'Cra 50 #30-40, Cali'),
('MountainBikes', 'Andrea Vargas', '3153217856', 'Calle 65 #23-15, Barranquilla'),
('ProCycling', 'Daniel Torres', '3009876543', 'Av. Bolivar #78-45, Bucaramanga'),
('VelocidadTotal', 'Carolina Ruiz', '3172589631', 'Cra 30 #12-35, Pereira'),
('EliteWheels', 'Santiago Mejia', '3045698712', 'Calle 80 #25-40, Cartagena'),
('BikeParadise', 'Monica Lopez', '3125874963', 'Av. El Dorado #120-56, Bogotá'),
('CyclingMasters', 'Felipe Ortiz', '3188529637', 'Cra 70 #45-20, Medellín'),
('GreenRides', 'Valentina Suarez', '3002589637', 'Calle 25 #18-30, Cali'),
('TurboBike', 'Andres Castro', '3174563219', 'Av. Circunvalar #45-28, Pasto'),
('EcoCycle', 'Marcela Gomez', '3019876543', 'Cra 15 #32-18, Santa Marta');

-- Insertar Productos (Relacionados con Categorías y Proveedores)
INSERT INTO Productos (id_categoria, id_proveedor, nombre, descripcion, precio_venta, stock) VALUES 
(1, 1, 'Bicicleta Montañera', 'Bicicleta para terrenos difíciles', 1500.00, 10),
(2, 2, 'Casco de seguridad', 'Casco de alta resistencia', 120.50, 20),
(3, 1, 'Guantes deportivos', 'Guantes acolchados para ciclismo', 35.00, 30),
(4, 3, 'Jersey de ciclismo', 'Camiseta profesional para ciclistas', 85.99, 15),
(5, 4, 'GPS para ciclismo', 'Dispositivo de seguimiento de rutas', 250.00, 8),
(6, 5, 'Kit de herramientas básico', 'Herramientas esenciales para reparaciones', 45.75, 12),
(7, 6, 'Aceite lubricante', 'Lubricante para cadena de alto rendimiento', 12.50, 40),
(8, 7, 'Set de luces LED', 'Luces recargables para día y noche', 65.30, 25),
(9, 8, 'Gel energético', 'Paquete de 10 geles energéticos', 28.90, 50),
(10, 9, 'Cambio trasero Shimano', 'Cambio de 10 velocidades de alta calidad', 85.25, 15),
(1, 10, 'Bicicleta de Ruta', 'Bicicleta ligera para carretera', 1800.00, 7),
(4, 11, 'Shorts acolchados', 'Shorts con almohadilla para mayor comodidad', 65.40, 22),
(2, 12, 'Botella térmica', 'Botella que mantiene la temperatura', 18.95, 35),
(3, 1, 'Cadena de recambio', 'Cadena resistente al desgaste', 25.75, 28),
(11, 2, 'Candado en U', 'Candado de alta seguridad', 42.60, 18);



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
    @id_categoria INT = NULL,
    @descripcion TEXT = NULL
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
    LEFT JOIN Categorias c ON p.id_categoria = c.id_categoria
    INNER JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor
    WHERE 
        (@id_categoria IS NULL OR p.id_categoria = @id_categoria) AND
        (@descripcion IS NULL OR p.descripcion LIKE CONCAT('%', @descripcion, '%'));
END;
GO




--
CREATE PROCEDURE sp_ObtenerProveedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        id_proveedor AS ID,
        nombre AS Nombre,
        contacto AS Contacto,
        telefono AS Teléfono,
        direccion AS Direccion
    FROM 
        Proveedores;
END;

--
GO

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
--

GO

CREATE PROCEDURE sp_ObtenerClientes
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        u.id_usuario AS ID,
        u.nombre AS Nombre,
		u.apellido AS Apellido
    FROM 
        Usuarios u
    WHERE 
        rol = 'Cliente'
    ORDER BY 
        Apellido, Nombre;
END
GO

CREATE PROCEDURE sp_ObtenerEmpleados
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        u.id_usuario AS ID,
        u.nombre AS Nombre,
        u.apellido AS Apellido
    FROM 
        Usuarios u
    WHERE 
        rol = 'Empleado'
    ORDER BY 
        Apellido, Nombre;
END
GO

CREATE PROCEDURE sp_ObtenerCategorias
AS
BEGIN
    SELECT id_categoria AS ID,
	nombre AS Nombre,
	descripcion AS Descripcion
    FROM Categorias;
END
GO

CREATE PROCEDURE sp_ObtenerFacturas
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH TotalesPorFactura AS
    (
        SELECT
            id_factura,
            SUM(cantidad * precio) AS Total
        FROM dbo.Detalles_Facturas
        GROUP BY id_factura
    )
    SELECT
        f.id_factura   AS ID,
        emp.nombre + ' ' + emp.apellido AS Empleado,
        CASE 
            WHEN f.tipo_factura = 'Venta' THEN cli.nombre + ' ' + cli.apellido
            ELSE NULL
        END AS Cliente,
        CASE 
            WHEN f.tipo_factura = 'Compra' THEN prov.nombre
            ELSE NULL
        END AS Proveedor,
        f.tipo_factura AS Tipo,
        f.fecha        AS Fecha,
        tpf.Total      AS Total
    FROM dbo.Facturas AS f
    INNER JOIN dbo.Usuarios AS emp
        ON f.id_empleado = emp.id_usuario
    LEFT JOIN dbo.Usuarios AS cli
        ON f.id_cliente  = cli.id_usuario
    LEFT JOIN dbo.Proveedores AS prov
        ON f.tipo_factura = 'Compra'
        AND prov.id_proveedor = f.id_empleado  
        -- O el join que corresponda a tu modelo de proveedor
    INNER JOIN TotalesPorFactura AS tpf
        ON f.id_factura = tpf.id_factura
    ORDER BY f.id_factura;
END;
GO



CREATE PROCEDURE sp_ObtenerFacturaPorId
	@id_factura INT
AS
BEGIN
	SET NOCOUNT ON;

-- Encabezado
	SELECT 
		f.id_factura       AS IdFactura,
		f.tipo_factura     AS Tipo,
		f.fecha            AS Fecha,
		f.id_cliente       AS IdCliente,
		f.id_empleado      AS IdEmpleado
	FROM Facturas f
	WHERE f.id_factura = @id_factura;

-- Detalles
	SELECT
		d.id_detalles      AS IdDetalle,
		d.id_producto      AS IdProducto,
		p.nombre           AS NombreProducto,
		d.cantidad         AS Cantidad,
		d.precio           AS Precio
	FROM Detalles_Facturas d
	JOIN Productos p ON p.id_producto = d.id_producto
	WHERE d.id_factura = @id_factura;
END
GO

CREATE PROCEDURE sp_ObtenerDetallesPorFactura
    @id_factura INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        df.id_detalles   AS ID,
        df.id_factura    AS FacturaID,
        df.id_producto   AS ProductoID,
        p.nombre         AS NombreProducto,
        df.cantidad      AS Cantidad,
        df.precio        AS Precio,
        (df.cantidad * df.precio) AS Subtotal
    FROM dbo.Detalles_Facturas AS df
    INNER JOIN dbo.Productos AS p
        ON df.id_producto = p.id_producto
    WHERE df.id_factura = @id_factura
    ORDER BY df.id_detalles;
END;
GO



--
CREATE PROCEDURE sp_AgregarProducto
    @nombre NVARCHAR(100),
    @categoria NVARCHAR(100) = NULL, 
    @descripcion NVARCHAR(255),
    @precio DECIMAL(10,2),
    @stock INT,
    @proveedor NVARCHAR(100)
AS
BEGIN
    DECLARE @id_categoria INT = NULL, @id_proveedor INT;
    
    IF @categoria IS NOT NULL
    BEGIN
        SELECT @id_categoria = id_categoria FROM Categorias WHERE nombre = @categoria;
        
        IF @id_categoria IS NULL
        BEGIN
            PRINT 'Error: La categoría especificada no existe.';
            RETURN;
        END
    END
    ELSE
    BEGIN
        -- Asignar categoría "Sin categoría" o NULL según tu diseño de base de datos
        -- Opción 1: Buscar una categoría por defecto
        -- SELECT @id_categoria = id_categoria FROM Categorias WHERE nombre = 'Sin categoría';
        
        -- Opción 2: Permitir NULL en la columna id_categoria
        SET @id_categoria = NULL;
    END

    -- Obtener el ID del proveedor (obligatorio)
    SELECT @id_proveedor = id_proveedor FROM Proveedores WHERE nombre = @proveedor;

    -- Verificar que exista el proveedor
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

CREATE PROCEDURE sp_AgregarProveedor
    @nombre VARCHAR(100),
    @contacto VARCHAR(100),
    @telefono VARCHAR(20),
    @direccion VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Proveedores (nombre, contacto, telefono, direccion)
    VALUES (@nombre, @contacto, @telefono, @direccion);

	SELECT SCOPE_IDENTITY() AS NuevoIdProveedor;
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
CREATE PROCEDURE sp_AgregarCliente
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Correo NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

        INSERT INTO Usuarios (
            nombre,
            apellido,
            correo,
            rol
        )
        VALUES (
            @Nombre,
            @Apellido,
            @Correo,
            'Cliente'
        );
        
        SELECT SCOPE_IDENTITY() AS NuevoClienteID;
        
END;
GO
--
CREATE PROCEDURE sp_AgregarCategoria
    @nombre VARCHAR(100),
    @descripcion TEXT
AS
BEGIN
    INSERT INTO Categorias (nombre, descripcion)
    VALUES (@nombre, @descripcion);
END
GO

CREATE PROCEDURE sp_AgregarProductoBasico
    @nombre       VARCHAR(100),
    @precio_venta DECIMAL(18,2),
    @stock        INT,
    @id_proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos (nombre, precio_venta, stock, id_proveedor)
    VALUES (@nombre, @precio_venta, @stock, @id_proveedor);
		SELECT SCOPE_IDENTITY() AS NuevoIdProducto;


END;
GO


CREATE PROCEDURE sp_InsertarFactura
    @tipo_factura  VARCHAR(50),
    @id_cliente    INT        = NULL,
    @id_empleado   INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @id_factura INT;

    -- Validaciones (tipo, empleado, cliente solo en Venta)
    IF @tipo_factura NOT IN ('Venta','Compra')
    BEGIN
        RAISERROR('Tipo de factura inválido',16,1); RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE id_usuario=@id_empleado)
    BEGIN
        RAISERROR('Empleado no encontrado',16,1); RETURN;
    END
    IF @tipo_factura='Venta'
       AND NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE id_usuario=@id_cliente)
    BEGIN
        RAISERROR('Cliente no encontrado',16,1); RETURN;
    END

    -- Insert factura
    IF @tipo_factura='Venta'
    BEGIN
        INSERT INTO dbo.Facturas(tipo_factura,id_cliente,id_empleado)
        VALUES(@tipo_factura,@id_cliente,@id_empleado);
    END
    ELSE
    BEGIN
        INSERT INTO dbo.Facturas(tipo_factura,id_empleado)
        VALUES(@tipo_factura,@id_empleado);
    END

    SET @id_factura = SCOPE_IDENTITY();
    SELECT @id_factura AS FacturaID;
END;
GO

CREATE PROCEDURE sp_InsertarDetalleFactura
    @id_factura  INT,
    @id_producto INT,
    @cantidad    INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @precio DECIMAL(10,2);

    -- Validar que la factura exista
    IF NOT EXISTS (SELECT 1 FROM dbo.Facturas WHERE id_factura=@id_factura)
    BEGIN
        RAISERROR('Factura %d no existe.',16,1,@id_factura); RETURN;
    END

    -- Validar producto y obtener precio
    IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE id_producto=@id_producto)
    BEGIN
        RAISERROR('Producto %d no existe.',16,1,@id_producto); RETURN;
    END
    SELECT @precio=precio_venta FROM dbo.Productos WHERE id_producto=@id_producto;

    -- Insert detalle
    INSERT INTO dbo.Detalles_Facturas(id_factura,id_producto,cantidad,precio)
    VALUES(@id_factura,@id_producto,@cantidad,@precio);
END;
GO


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

CREATE PROCEDURE sp_ActualizarProveedor
    @id_proveedor INT,
    @nombre VARCHAR(100),
    @contacto VARCHAR(100),
    @telefono VARCHAR(20),
    @direccion VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedores
    SET 
        nombre = @nombre,
        contacto = @contacto,
        telefono = @telefono,
        direccion = @direccion
    WHERE 
        id_proveedor = @id_proveedor;
END;

GO

CREATE PROCEDURE sp_ActualizarCategoria
    @id_categoria INT,
    @nombre VARCHAR(100),
    @descripcion TEXT
AS
BEGIN
    UPDATE Categorias
    SET nombre = @nombre,
        descripcion = @descripcion
    WHERE id_categoria = @id_categoria;
END
GO

CREATE PROCEDURE sp_ActualizarFactura
    @id_factura   INT,
    @tipo_factura VARCHAR(10),
    @id_cliente   INT      = NULL,
    @id_empleado  INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Facturas
    SET 
        tipo_factura = @tipo_factura,
        id_cliente   = @id_cliente,
        id_empleado  = @id_empleado
    WHERE id_factura = @id_factura;
END
GO


CREATE PROCEDURE sp_ReemplazarDetallesFactura
    @id_factura INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Detalles_Facturas WHERE id_factura = @id_factura;
END
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