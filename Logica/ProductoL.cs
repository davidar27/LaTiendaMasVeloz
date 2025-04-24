using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.DTO;
using Microsoft.Data.SqlClient;
using Modelo;
using Modelo.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
    public class ProductoL
    {
        private ProductoM productoM = new ProductoM();

        public DataTable ObtenerProductosL()
        {
            DataTable productos = productoM.ObtenerProductosM();
            return productos;
        }

        public void AgregarProductoL(string nombre, string? categoria, string? descripcion, decimal precio, int stock, string proveedor)
        {
            Producto producto = new Producto
            {
                Nombre = nombre,
                Categoria = categoria,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                Proveedor = proveedor
            };
            productoM.AgregarProductosM(producto);
        }
        public int AgregarProductoBasicoL(string nombre, decimal precio, int stock, string proveedor)
        {
            Producto producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Stock = stock,
                Proveedor = proveedor
            };
            int idProducto = productoM.AgregarProductoBasicoM(producto);
            return idProducto;
        }

        public void EditarProductoL(int id, string nombre, string categoria, string descripcion, decimal precio, int stock, string proveedor)
        {
            Producto producto = new Producto
            {
                Id = id,
                Nombre = nombre,
                Categoria = categoria,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                Proveedor = proveedor
            };

            productoM.EditarProductoM(producto);
        }

        public void EliminarProductoL(string nombre)
        {
            productoM.EliminarProductoM(nombre);
        }

        
        public List<ProductoDTO> ObtenerProductosPorProveedorM(string idProveedor)
        {
            List<ProductoDTO> productos = new List<ProductoDTO>();

            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT id_producto, nombre, precio_venta, stock FROM Productos WHERE id_Proveedor = @id_Proveedor";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_Proveedor", idProveedor);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new ProductoDTO
                    {
                        Id = Convert.ToInt32(reader["id_producto"]),
                        Nombre = reader["nombre"].ToString(),
                        Precio = Convert.ToDecimal(reader["precio_venta"]),
                        Stock = Convert.ToInt32(reader["stock"])
                    });
                }
            }

            return productos;
        }
    }

}
