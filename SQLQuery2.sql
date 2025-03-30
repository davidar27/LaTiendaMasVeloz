
-- Crear la base de datos
CREATE DATABASE InventarioTienda;
GO

-- Usar la base de datos
USE InventarioTienda;
GO

-- Crear la tabla de Usuarios
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    rol VARCHAR(20) CHECK (rol IN ('vendedor', 'administrador')) NOT NULL
);
GO

-- Crear la tabla de Productos
CREATE TABLE Productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
    imagen_url VARCHAR(255) NULL
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
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED,
    FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO

-- Crear la tabla de Alertas de Stock
CREATE TABLE Alertas_Stock (
    id_alerta INT IDENTITY(1,1) PRIMARY KEY,
    id_producto INT NOT NULL,
    stock_actual INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto) ON DELETE CASCADE
);
GO

-- Insertar productos de prueba
INSERT INTO Productos (nombre, descripcion, precio_venta, stock)
VALUES 
('Bicicleta de Montaña', 'Bicicleta todo terreno para montaña', 1200.00, 10),
('Asiento de Gel', 'Asiento cómodo con gel para bicicletas', 50.00, 25),
('Casco Protector', 'Casco de seguridad para ciclistas', 35.00, 30),
('Guantes de Ciclismo', 'Guantes acolchados para ciclismo', 20.00, 15),
('Luz LED Frontal', 'Luz LED para bicicletas, carga USB', 15.00, 50);


GO

/*
-- ==============================
-- 📌 TRIGGERS
-- ==============================

-- 🔹 TRIGGER: Actualizar stock después de una venta
CREATE TRIGGER trg_ActualizarStock
ON Detalle_Ventas
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE p
    SET p.stock = p.stock - dv.cantidad
    FROM Productos p
    INNER JOIN inserted dv ON p.id_producto = dv.id_producto;

    INSERT INTO Alertas_Stock (id_producto, stock_actual)
    SELECT id_producto, stock
    FROM Productos
    WHERE stock < 5;
END;
GO

-- 🔹 TRIGGER: Evitar ventas sin stock suficiente
CREATE TRIGGER trg_PrevenirVentaSinStock
ON Detalle_Ventas
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Productos p ON i.id_producto = p.id_producto
        WHERE i.cantidad > p.stock
    )
    BEGIN
        RAISERROR('No se puede realizar la venta, stock insuficiente.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO Detalle_Ventas (id_venta, id_producto, cantidad, precio_unitario)
        SELECT id_venta, id_producto, cantidad, precio_unitario
        FROM inserted;
    END;
END;
GO

-- 🔹 TRIGGER: Prevenir eliminación de usuarios si tienen ventas registradas
CREATE TRIGGER trg_PrevenirEliminarUsuario
ON Usuarios
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM Ventas WHERE id_usuario IN (SELECT id_usuario FROM deleted)
    )
    BEGIN
        RAISERROR('No se puede eliminar el usuario porque tiene ventas registradas.', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        DELETE FROM Usuarios WHERE id_usuario IN (SELECT id_usuario FROM deleted);
    END
END;
GO
*/
-- ==============================
-- 📌 PROCEDIMIENTOS ALMACENADOS
-- ==============================


CREATE PROCEDURE sp_InsertarProducto
    @nombre VARCHAR(100),
    @descripcion TEXT = NULL,
    @precio_venta DECIMAL(10,2),
    @stock INT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Validar que el stock no sea negativo
        IF @stock < 0
        BEGIN
            RAISERROR('El stock no puede ser un valor negativo.', 16, 1);
            RETURN;
        END
        
        -- Validar que el precio no sea negativo
        IF @precio_venta <= 0
        BEGIN
            RAISERROR('El precio de venta debe ser mayor que cero.', 16, 1);
            RETURN;
        END
        
        -- Insertar el nuevo producto
        INSERT INTO Productos (
            nombre,
            descripcion,
            precio_venta,
            stock
        ) VALUES (
            @nombre,
            @descripcion,
            @precio_venta,
            @stock
        );
        
        -- Retornar el ID del producto insertado
        SELECT SCOPE_IDENTITY() AS id_producto;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO


-- 🔹 SP: Mostar todos los productos

GO
CREATE PROCEDURE sp_MostrarProductos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.id_producto AS ID, p.nombre AS Nombre_Producto, c.nombre_categoria AS Categoria, p.descripcion AS Descripcion, p.stock AS Stock, p.precio_venta AS Precio
FROM productos p
JOIN categorias c ON p.id_categoria = c.id_categoria;
END;
GO

CREATE PROCEDURE sp_ListarCategorias
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  nombre_categoria FROM categorias;
END;
exec sp_ListarCategorias;
GO
CREATE PROCEDURE sp_InsertarCategoria
    @nombre_categoria VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si la categoría ya existe
    IF NOT EXISTS (SELECT 1 FROM categorias WHERE nombre_categoria = @nombre_categoria)
    BEGIN
        INSERT INTO categorias (nombre_categoria) VALUES (@nombre_categoria);
    END
END;





/*
-- 🔹 SP: Registrar una venta con productos
CREATE PROCEDURE sp_RegistrarVenta
    @id_usuario INT,
    @productos NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @id_venta INT;
    DECLARE @total DECIMAL(10,2) = 0;

    INSERT INTO Ventas (id_usuario, total)
    VALUES (@id_usuario, 0);
    SET @id_venta = SCOPE_IDENTITY();

    DECLARE @id_producto INT, @cantidad INT, @precio DECIMAL(10,2);
    DECLARE cur CURSOR FOR
    SELECT value FROM OPENJSON(@productos)
    WITH (
        id_producto INT '$.id_producto',
        cantidad INT '$.cantidad',
        precio DECIMAL(10,2) '$.precio'
    );

    OPEN cur;
    FETCH NEXT FROM cur INTO @id_producto, @cantidad, @precio;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO Detalle_Ventas (id_venta, id_producto, cantidad, precio_unitario)
        VALUES (@id_venta, @id_producto, @cantidad, @precio);

        SET @total = @total + (@cantidad * @precio);
        FETCH NEXT FROM cur INTO @id_producto, @cantidad, @precio;
    END;
    CLOSE cur;
    DEALLOCATE cur;

    UPDATE Ventas SET total = @total WHERE id_venta = @id_venta;
END;
GO

-- 🔹 SP: Filtrar facturas por vendedor, mes o periodo de tiempo
CREATE PROCEDURE sp_FiltrarFacturas
    @id_usuario INT = NULL,
    @mes INT = NULL,
    @fecha_inicio DATE = NULL,
    @fecha_fin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.id_venta, u.nombre AS vendedor, v.fecha, v.total
    FROM Ventas v
    JOIN Usuarios u ON v.id_usuario = u.id_usuario
    WHERE 
        (@id_usuario IS NULL OR v.id_usuario = @id_usuario)
        AND (@mes IS NULL OR MONTH(v.fecha) = @mes)
        AND (@fecha_inicio IS NULL OR v.fecha >= @fecha_inicio)
        AND (@fecha_fin IS NULL OR v.fecha <= @fecha_fin)
    ORDER BY v.fecha DESC;
END;
GO

-- 🔹 SP: Consultar productos escasos
CREATE PROCEDURE sp_ProductosEscasos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id_producto, nombre, stock
    FROM Productos
    WHERE stock < 5
    ORDER BY stock ASC;
END;
GO

-- 🔹 SP: Eliminar una venta y restaurar stock
CREATE PROCEDURE sp_EliminarVenta
    @id_venta INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Productos
    SET stock = stock + dv.cantidad
    FROM Productos p
    INNER JOIN Detalle_Ventas dv ON p.id_producto = dv.id_producto
    WHERE dv.id_venta = @id_venta;

    DELETE FROM Detalle_Ventas WHERE id_venta = @id_venta;
    DELETE FROM Ventas WHERE id_venta = @id_venta;
END;
GO*/