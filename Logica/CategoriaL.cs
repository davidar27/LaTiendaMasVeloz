using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.DTO;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class CategoriaL
    {
        private CategoriaM categoriaM = new CategoriaM();

        public DataTable ObtenerCategoriasL()
        {
            DataTable categorias = categoriaM.ObtenerCategoriasM();
            return categorias;
        }


        public void AgregarCategoriaL(string nombre, string descripcion)
        {
            Categoria categoria = new Categoria
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            categoriaM.AgregarCategoriaM(categoria);
        }


        public void EditarCategoriaL(int id, string nombre, string descripcion)
        {
            Categoria categoria = new Categoria
            {
                Id = id,
                Nombre = nombre,
                Descripcion = descripcion
            };

            categoriaM.EditarCategoriaM(categoria);
        }


        public void EliminarCategoriaL(string nombre)
        {
            categoriaM.EliminarCategoriaM(nombre);
        }
    }
}
