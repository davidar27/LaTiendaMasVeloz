using System.Data;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class frmFactura : Form
    {

        private FacturaL facturaL = new FacturaL();
        private ProductoL productoL = new ProductoL();
        private bool modoEdicion = false;
        private DataGridViewRow filaEditable = null;
        private DataTable tablaOriginal;
        private string datos = null;
        public BindingSource bindingSource = null;
        public frmFactura()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = productoL.ObtenerProductosL();

                List<Producto> productos = dt.AsEnumerable()
                    .Select(row => new Producto
                    {
                        Nombre = row.Field<string>("nombre"),
                    })
                    .ToList();

                comboBoxProductos.DataSource = productos;
                comboBoxProductos.DisplayMember = "ToString";
                comboBoxProductos.ValueMember = "Nombre";
                Producto seleccionado = (Producto)comboBoxProductos.SelectedItem;


                dgvDatos.DataSource = productoL.ObtenerProductosL();




                dgvDatos.Columns["ID"].DisplayIndex = 0;
                dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                dgvDatos.Columns["Categoria"].Visible = false;
                dgvDatos.Columns["Descripcion"].Visible = false;
                dgvDatos.Columns["Precio"].DisplayIndex = 2;
                dgvDatos.Columns["Stock"].DisplayIndex = 3;
                dgvDatos.Columns["Proveedor"].DisplayIndex = 4;
                dgvDatos.Columns["Fecha"].Visible = false;
                dgvDatos.Columns["btnAgregar"].DisplayIndex = 5;

                foreach (DataGridViewColumn col in dgvDatos.Columns)
                {
                    col.ReadOnly = !(col is DataGridViewTextBoxColumn) ||
                                   col.Name == "btnAgregar";

                }
                dgvDatos.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
