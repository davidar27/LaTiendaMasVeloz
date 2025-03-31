using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class UsuarioL
    {
        private UsuarioM usuarioM = new UsuarioM();

        public DataTable ObtenerUsuariosL()
        {
            try
            {
                DataTable usuarios = usuarioM.ObtenerUsuariosM();

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
        }

        public void AgregarUsuarioL(string nombre, string apellido, string correo, string contraseña,  string rol)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Correo = contraseña;
                usuario.Contraseña = contraseña;
                usuario.Rol = rol;
                usuarioM.AgregarProductosM(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar producto: " + ex.Message);
            }
        }
    }
}
