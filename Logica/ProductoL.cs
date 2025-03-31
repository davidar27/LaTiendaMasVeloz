using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                DataTable productos = productoM.ObtenerProductosM();

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
        }
        public void AgregarProductoL(string nombre, string categoria, string descripcion, decimal precio, int stock, string proveedor)
        {
            try
            {
                Producto producto = new Producto();
                producto.Nombre = nombre;
                producto.Categoria = categoria;
                producto.Descripcion = descripcion;
                producto.Precio = precio;
                producto.Stock = stock;
                producto.Proveedor = proveedor;
                productoM.AgregarProductosM(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar producto: " + ex.Message);
            }
        }

        public void EditarProductoL(int id, string nombre, string categoria, string descripcion, decimal precio,int stock, string proveedor)
        {
            try
            {

                var producto = new Producto
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
            catch (Exception ex)
            {
                throw new Exception("Error al editar producto: " + ex.Message);
            }
        }
        public void EliminarProductoL(string nombre)
        {
            try
            {
                var resultado = productoM.EliminarProductoM(nombre);

                if (!resultado.Success)
                {
                    throw new Exception(resultado.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }


    }


}
