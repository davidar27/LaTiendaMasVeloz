using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Principal
{
    public partial class frmPrincipal: Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            //ConfigurarMenuSegunRol();
        }

        //private void ConfigurarMenuSegunRol()
        //{
        //    // Mostrar/ocultar opciones según el rol del usuario
        //    if (Sesion.UsuarioActual.Rol == "Administrador")
        //    {
        //        // Mostrar todas las opciones
        //    }
        //    else if (Sesion.UsuarioActual.Rol == "Empleado")
        //    {
        //        // Ocultar opciones de administración
        //        usuariosToolStripMenuItem.Visible = false;
        //    }
        //}

        //private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmProductos frm = new frmProductos();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmVentas frm = new frmVentas();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
