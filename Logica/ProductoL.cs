using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            DataTable productos = productoM.ObtenerProductosM();
            return productos;
        }

        public void AgregarProductoL(string nombre, string categoria, string descripcion, decimal precio, int stock, string proveedor)
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
    }

}
