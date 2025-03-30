using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Logica
{
    public class ProductoLogic
    {
        private ProductoData productoData = new ProductoData();

        public DataTable MostrarProductos()
        {
            DataTable table = new DataTable();
            table = productoData.Mostrar();
            return table;
        }

        public void InsertarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            productoData.InsertarProducto(nombre, descripcion, precio, stock);
        }

        public void EditarProducto(int id, string nombre, string descripcion, decimal precio, int stock)
        {
            productoData.EditarProducto(id, nombre, descripcion, precio, stock);
        }

        public void EliminarProducto(int id)
        {
            productoData.EliminarProducto(id);
        }
    }
}
