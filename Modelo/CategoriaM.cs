using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelo.Entities;

namespace Modelo
{
    public class CategoriaM
    {

        public DataTable ObtenerCategoriasM()
        {
            DataTable categorias = new DataTable();

            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                using (SqlCommand command = new SqlCommand("sp_ObtenerCategorias", connection))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    Debug.WriteLine(categorias);
                    da.Fill(categorias);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener productos: " + ex.Message, ex);
            }

            return categorias;
        }


        public void AgregarCategoriaM(Categoria categoria)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AgregarCategoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@descripcion", categoria.Descripcion ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar categoría: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar categoría: " + ex.Message, ex);
            }
        }

        public void EditarCategoriaM(Categoria categoria)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ActualizarCategoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_categoria", categoria.Id);
                        command.Parameters.AddWithValue("@nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@descripcion", categoria.Descripcion ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar categoría: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al editar categoría: " + ex.Message, ex);
            }
        }

        public void EliminarCategoriaM(string nombre)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Categorias WHERE nombre = @nombre";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    throw new Exception("No se puede eliminar la categoria porque está relacionado con otras tablas.", ex);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error SQL al eliminar categoria: " + ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al eliminar categoria: " + ex.Message, ex);
                }
            }
        }

    }
}
