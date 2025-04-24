using System.Data;
using Logica.DTO;
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

        public DataTable ObtenerProveedoresL()
        {
            DataTable proveedores = usuarioM.ObtenerProveedoresM();
            return proveedores;
        }

        public List<ClienteDTO> ObtenerClientesL()
        {
            var clientes = usuarioM.ObtenerClientesM();
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                NombreCompleto = $"{c.Nombre} {c.Apellido}".Trim(),
            }).ToList();
        }

        public List<EmpleadoDTO> ObtenerEmpleadosL()
        {
            var empleados = usuarioM.ObtenerEmpleadosM();
            return empleados.Select(c => new EmpleadoDTO
            {
                Id = c.Id,
                NombreCompleto = $"{c.Nombre} {c.Apellido}".Trim(),
            }).ToList();
        }
        public List<ProveedorDTO> ListaProveedoresL()
        {
            var proveedores = usuarioM.ObtenerListaProveedoresM();
            return proveedores.Select(p => new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToList();
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
        public Usuario AgregarClienteL(string nombre, string registro1, string registro2)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Apellido = registro1;
            usuario.Correo = registro2;
            usuarioM.AgregarClienteM(usuario);
            return usuario;
        }

        public int AgregarProveedorL(string nombre, string contacto, string telefono, string direccion)
        {
            var  proveedor = new Proveedor();
            proveedor.Nombre = nombre;
            proveedor.Contacto = contacto;
            proveedor.Telefono = telefono;
            proveedor.Direccion = direccion;

            int idProveedor = usuarioM.AgregarProveedorM(proveedor);
            return idProveedor;
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

        public void EditarProveedorL(int id, string nombre, string contacto, string telefono, string direccion)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Id = id;
            proveedor.Nombre = nombre;
            proveedor.Contacto = contacto;
            proveedor.Telefono = telefono;
            proveedor.Direccion = direccion;

            usuarioM.EditarProveedorM(proveedor);
        }

        public void EliminarUsuarioL(string correo)
        {
            Usuario usuario = new Usuario();
            usuario.Correo = correo;
            usuarioM.EliminarUsuarioM(correo);
        }

        public void EliminarProveedorL(string nombre)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Nombre = nombre;
            usuarioM.EliminarProveedorM(nombre);
        }


        public bool ValidarUsuarioL(string correo, string contraseña)
        {
            return usuarioM.ValidarUsuarioM(correo, contraseña);

        }
    }
}
