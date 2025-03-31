using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelo.Entities;

namespace Modelo
{
    public class ProductoM
    {

        public DataTable ObtenerProductosM()
        {
            DataTable productos = new DataTable();
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    string query = "sp_ObtenerProductos";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(productos);
                       
                    }
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

            return productos;
        }
        public void AgregarProductosM(Producto producto)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_AgregarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre ?? (object)DBNull.Value;
                        command.Parameters.Add("@categoria", SqlDbType.NVarChar, 100).Value = producto.Categoria ?? (object)DBNull.Value;
                        command.Parameters.Add("@descripcion", SqlDbType.NVarChar, 255).Value = producto.Descripcion ?? (object)DBNull.Value;
                        command.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.Precio;
                        command.Parameters.Add("@stock", SqlDbType.Int).Value = producto.Stock;
                        command.Parameters.Add("@proveedor", SqlDbType.NVarChar, 100).Value = producto.Proveedor ?? (object)DBNull.Value;

                        var returnParam = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParam.Direction = ParameterDirection.ReturnValue;

                        command.ExecuteNonQuery();

                        switch ((int)returnParam.Value)
                        {
                            case 1:
                                throw new Exception("La categoría no existe");
                            case 2:
                                throw new Exception("El proveedor no existe");
                            case 0:
                                break;
                            default:
                                throw new Exception("Error desconocido al agregar producto");
                        }
                    }
                }
                catch (SqlException ex) when (ex.Number == -2)
                {
                    throw new Exception("Timeout al conectar con la base de datos", ex);
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error SQL ({ex.Number}): {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inesperado: {ex.Message}", ex);
                }
            }
        }

        public void EditarProductoM(Producto producto)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_ActualizarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_producto", producto.Id);
                        command.Parameters.AddWithValue("@nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@categoria", producto.Categoria);
                        command.Parameters.AddWithValue("@descripcion", producto.Descripcion ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@precio", producto.Precio);
                        command.Parameters.AddWithValue("@stock", producto.Stock);
                        command.Parameters.AddWithValue("@proveedor", producto.Proveedor ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                        


                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error SQL al editar producto: " + ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al editar producto: " + ex.Message, ex);
                }
            }
        }
        public (bool Success, string Message) EliminarProductoM(string nombre)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Productos WHERE nombre = @nombre";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0
                            ? (true, "Producto eliminado correctamente")
                            : (false, "No se encontró el producto a eliminar");
                    }
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    return (false, "No se puede eliminar: El producto tiene registros relacionados");
                }
                catch (SqlException ex)
                {
                    return (false, $"Error SQL al eliminar: {ex.Message}");
                }
                catch (Exception ex)
                {
                    return (false, $"Error inesperado al eliminar: {ex.Message}");
                }
            }
        }

  
    }
}

