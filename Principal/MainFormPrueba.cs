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

namespace Principal
{
    public partial class MainFormPrueba : Form
    {

        ProductoLogic productoLogic = new ProductoLogic();
        public MainFormPrueba()
        {
            InitializeComponent();
            MostrarProdctos();

        }
        private void MostrarProdctos()
        {

            dgvProducts.DataSource = productoLogic.MostrarProductos();
        }


        private void ConfigurarDataGridView()
        {
            if (!dgvProducts.Columns.Contains("Opciones"))
            {
                DataGridViewButtonColumn btn_Editar = new DataGridViewButtonColumn();
                btn_Editar.Text = "Editar";
                dgvProducts.Columns.Add(btn_Editar);
                btn_Editar.UseColumnTextForButtonValue = true;


                DataGridViewImageColumn colEliminar = new DataGridViewImageColumn();
                colEliminar.Image = Image.FromStream(new MemoryStream(Properties.Resources.delete));
                colEliminar.Name = "Eliminar";
                dgvProducts.Columns.Add(colEliminar);
            }


        }

        private void pictureHeader_Click(object sender, EventArgs e)
        {

        }

        private void tableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelGestion_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainFormPrueba_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        private void linkLabelAjust_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnAgregarProduct_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dgvProducts.DataSource;
            DataRow newRow = dataTable.NewRow();
            newRow["Nombre_Producto"] = "Default Product Name";
            newRow["Categoria"] = "Default Product Name";
            newRow["Descripcion"] = "Default Product Name";
            newRow["Precio"] = 0;
            newRow["Stock"] = 0;
            dataTable.Rows.Add(newRow);
            dgvProducts.DataSource = dataTable;

            btnAgregarProduct.Text = "Guardar Producto";


            dgvProducts.ReadOnly = false;
            dgvProducts.AllowUserToAddRows = true;
            dgvProducts.AllowUserToDeleteRows = true;
            dgvProducts.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        }
    }
}
