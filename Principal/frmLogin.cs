using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using static System.Collections.Specialized.BitVector32;

namespace Principal
{
    public partial class frmLogin: Form
    {
        private UsuarioL usuarioBL = new UsuarioL();

        public frmLogin()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string usuario = txtUsuario.Text;
        //        string contraseña = txtContraseña.Text;

        //        Usuario user = usuarioBL.ValidarUsuario(usuario, contraseña);

        //        if (user != null)
        //        {
        //            // Guardar usuario en sesión
        //            Sesion.UsuarioActual = user;

        //            // Mostrar formulario principal
        //            frmPrincipal principal = new frmPrincipal();
        //            principal.Show();
        //            this.Hide();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Usuario o contraseña incorrectos", "Error",
        //                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error",
        //                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
// Clase para manejar sesión
//public static class Sesion
//{
//    public static Usuario UsuarioActual { get; set; }
//}