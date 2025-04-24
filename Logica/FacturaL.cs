using System.Data;
using System.Diagnostics;
using Logica.DTO;
using Modelo;
using Modelo.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Logica
{
    public class FacturaL
    {

        private FacturaM facturaM = new FacturaM();
        private ProductoM productoM = new ProductoM();
        private UsuarioM usuarioM = new UsuarioM();
        private ProductoL productoL = new ProductoL();

        private List<ProductoFacturaDTO> productosFactura = new List<ProductoFacturaDTO>();




       


        public void AgregarProductoL(ProductoFacturaDTO producto)
        {
            if (!productosFactura.Any(p => p.Id == producto.Id))
            {
                productosFactura.Add(producto);
            }
            else
            {
                throw new Exception("El producto ya está en la factura.");
            }
        }

        public List<Producto> ObtenerListaProductos()
        {
            DataTable dt = productoM.ObtenerProductosM();
            return dt.AsEnumerable()
                .Select(row => new Producto
                {
                    Id = row.Field<int>("ID"),
                    Nombre = row.Field<string>("nombre"),
                    Precio = row.Field<decimal>("precio"),
                    Stock = row.Field<int>("stock"),
                })
                .ToList();
        }

        public List<ProductoDTO> ObtenerProductosPorProveedorL(string idProveedor)
        {
            return productoL.ObtenerProductosPorProveedorM(idProveedor);
        }

        public List<ProductoDTO> ObtenerProductosDTO()
        {
            List<Producto> productos = ObtenerListaProductos();
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();
        }


        

        public List<ProductoFacturaDTO> ObtenerProductosFactura()
        {
            return productosFactura;
        }

        public void LimpiarFactura()
        {
            productosFactura.Clear();
        }

        public bool ProductoExisteEnFactura(int productoId)
        {
            return ObtenerProductosFactura().Any(p => p.Id == productoId);
        }
        public DataTable ObtenerFacturaL()
        {
            DataTable Factura = facturaM.ObtenerFacturasM();
            return Factura;
        }

        public DataTable ObtenerDetallesFacturaL(int idFactura)
        {
            DataTable detallesFactura = facturaM.ObtenerDetallesFacturaM(idFactura);
            return detallesFactura;
        }


        public void EliminarProducto(int productoId)
        {
            var productos = ObtenerProductosFactura();
            var productoAEliminar = productos.FirstOrDefault(p => p.Id == productoId);

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
            }
        }


        public void EliminarFacturaL(string idfactura)
        {
            facturaM.EliminarFacturaM(idfactura);
        }


        //public Factura ObtenerFacturaPorIdL(int idFactura)
        //{
        //    facturaM.ObtenerFacturaPorIdM(idFactura);
        //}


        public void EditarFacturaL(Factura factura)
        {
            facturaM.EditarFacturaM(factura);
        }


        public int CrearFacturaL(string tipoFactura, int? idCliente, int idEmpleado)
        {
            if (string.IsNullOrWhiteSpace(tipoFactura))
                throw new ArgumentException("El tipo de factura no puede estar vacío");

            if (tipoFactura == "Venta" && (!idCliente.HasValue || idCliente <= 0))
                throw new ArgumentException("El ID del cliente debe ser mayor que cero para facturas de venta");

            if (idEmpleado <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero");

            return facturaM.AgregarFacturaM(tipoFactura, idCliente, idEmpleado);
        }

        
        public void AgregarDetalleFacturaL(int idFactura, int idProducto, int cantidad)
        {
            // Validaciones
            if (idFactura <= 0)
                throw new ArgumentException("El ID de la factura debe ser mayor que cero");

            if (idProducto <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero");

            facturaM.AgregarDetalleFacturaM(idFactura, idProducto, cantidad);
        }

    }
}
