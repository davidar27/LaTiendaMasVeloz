using System.Data;
using Microsoft.Data.SqlClient;
using Modelo.Entities;

namespace Modelo
{
    public class UsuarioM
    {
        private readonly ConexionBD connection = new ConexionBD();

        public DataTable ObtenerUsuariosM()
        {
            DataTable usuarios = new DataTable();

            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("sp_ObtenerUsuarios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(usuarios);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener usuarios: " + ex.Message, ex);
            }

            return usuarios;
        }

        public bool ValidarUsuarioM(string correo, string contraseña)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE correo = @correo AND contraseña = @contraseña AND rol = 'Administrador'", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@contraseña", contraseña);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Usuario usuario = new Usuario
                                    {
                                        Id = dr.GetInt32(0),
                                        Correo = dr.GetString(1),
                                        Nombre = dr.GetString(2),
                                        Apellido = dr.GetString(3),
                                        Contraseña = dr.GetString(4),
                                        Rol = dr.GetString(5)
                                    };
                                }
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al validar usuario: " + ex.Message, ex);
            }
        }


        public void AgregarUsuarioM(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AgregarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                        command.Parameters.AddWithValue("@rol", usuario.Rol);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar usuario: " + ex.Message, ex);
            }
        }

        public void EditarUsuarioM(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ActualizarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_usuario", usuario.Id);
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                        command.Parameters.AddWithValue("@rol", usuario.Rol);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al editar usuario: " + ex.Message, ex);
            }
        }

        public void EliminarUsuarioM(string correo)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Usuarios WHERE correo = @correo", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@correo", correo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar usuario: " + ex.Message, ex);
            }
        }


    }
}
