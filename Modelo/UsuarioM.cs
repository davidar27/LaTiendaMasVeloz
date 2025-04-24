using System.Data;
using Microsoft.Data.SqlClient;
using Modelo.Entities;

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

        public DataTable ObtenerProveedoresM()
        {
            DataTable proveedores = new DataTable();

            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("sp_ObtenerProveedores", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(proveedores);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener proveedores: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener proveedores: " + ex.Message, ex);
            }

            return proveedores;
        }

        public List<Usuario> ObtenerClientesM()
        {
            var clientes = new List<Usuario>();

            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                var command = new SqlCommand("sp_ObtenerClientes", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Usuario
                        {
                            Id = reader.GetInt32(0),          
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2)
                        });
                    }
                }
            }

            return clientes;
        }

        public List<Usuario> ObtenerEmpleadosM()
        {
            var empleados = new List<Usuario>();

            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                var command = new SqlCommand("sp_ObtenerEmpleados", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Usuario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2)
                        });
                    }
                }
            }

            return empleados;
        }

        public List<Proveedor> ObtenerListaProveedoresM()
        {
            var proveedores = new List<Proveedor>();

            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                var command = new SqlCommand("sp_ObtenerProveedores", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            Id = reader.GetInt32(0),          
                            Nombre = reader.GetString(1),       
                            Contacto = reader.GetString(2),
                            Telefono = reader.GetString(3)
                        });
                    }
                }
            }

            return proveedores;
        }



        public bool ValidarUsuarioM(string correo, string contraseña)   
        {
            try
            {

                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();

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
                    connection.Close();
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


        public void AgregarClienteM(Usuario usuario)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AgregarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@correo", usuario.Correo);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public int AgregarProveedorM(Proveedor proveedor)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AgregarProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                        command.Parameters.AddWithValue("@contacto", proveedor.Contacto);
                        command.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                        command.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                        object result = command.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar proveedor: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar proveedor: " + ex.Message, ex);
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

        public void EditarProveedorM(Proveedor proveedor)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ActualizarProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_proveedor", proveedor.Id);
                        command.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                        command.Parameters.AddWithValue("@contacto", proveedor.Contacto);
                        command.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                        command.Parameters.AddWithValue("@direccion", proveedor.Direccion);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar proveedor: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al editar proveedor: " + ex.Message, ex);
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

        public void EliminarProveedorM(string nombre)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Proveedores WHERE nombre = @nombre", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar proveedor: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar proveedor: " + ex.Message, ex);
            }
        }

    }
}
