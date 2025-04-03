using System.Data;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class UsuarioL
    {
        UsuarioM usuarioM = new UsuarioM();

        public DataTable ObtenerUsuariosL()
        {
            DataTable usuarios = usuarioM.ObtenerUsuariosM();
            return usuarios;

        }

        public void AgregarUsuarioL(string nombre, string apellido, string correo, string contraseña, string rol)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Correo = contraseña;
            usuario.Contraseña = contraseña;
            usuario.Rol = rol;
            usuarioM.AgregarUsuarioM(usuario);
        }

        public void EditarUsuarioL(int id, string nombre, string apellido, string correo, string contraseña, string rol)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Correo = contraseña;
            usuario.Contraseña = contraseña;
            usuario.Rol = rol;
            usuarioM.EditarUsuarioM(usuario);
        }


        public void EliminarUsuarioL(string correo)
        {
            Usuario usuario = new Usuario();
            usuario.Correo = correo;
            usuarioM.EliminarUsuarioM(correo);
        }


        public bool ValidarUsuarioL(string correo, string contraseña)
        {
            return usuarioM.ValidarUsuarioM(correo, contraseña);

        }
    }
}
