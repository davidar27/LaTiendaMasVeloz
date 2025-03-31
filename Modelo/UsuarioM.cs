using Microsoft.Data.SqlClient;
using Modelo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioM
    {

        public DataTable ObtenerUsuariosM()
        {
            DataTable usuarios = new DataTable();
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    string query = "sp_ObtenerUsuarios";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(usuarios);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return usuarios;
        }


        public void AgregarProductosM(Usuario usuario)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_AgregarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = usuario.Nombre ?? (object)DBNull.Value;
                        command.Parameters.Add("@apellido", SqlDbType.NVarChar, 100).Value = usuario.Apellido ?? (object)DBNull.Value;
                        command.Parameters.Add("@correo", SqlDbType.NVarChar, 100).Value = usuario.Correo ?? (object)DBNull.Value;
                        command.Parameters.Add("@contraseña", SqlDbType.NVarChar, 100).Value = usuario.Contraseña ?? (object)DBNull.Value;
                        command.Parameters.Add("@rol", SqlDbType.NVarChar, 100).Value = usuario.Rol ?? (object)DBNull.Value;




                        command.ExecuteNonQuery();

                    }
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
    }
}
