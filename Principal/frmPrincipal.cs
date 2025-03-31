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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }


        private void btnCliente_Click(object sender, EventArgs e)
        {

        }


        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmVentas frm = new frmVentas();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
