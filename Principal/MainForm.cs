using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Logica;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Principal
{
    public partial class MainForm : Form
    {
        private ProductoLogic productoLogic = new ProductoLogic();

        public MainForm()
        {
            InitializeComponent();
            ConfigurarFormulario();
            Screen currentScreen = Screen.FromControl(this);
            this.Size = new Size(currentScreen.WorkingArea.Width, currentScreen.WorkingArea.Height);
            this.Location = currentScreen.WorkingArea.Location;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            MostrarProdctos();
            ConfigurarDataGridView();
        }
        private void MostrarProdctos()
        {

            dgvProductos.DataSource = productoLogic.MostrarProductos();
        }


        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProducto = dgvProductos.Rows[e.RowIndex].Cells["id_producto"].Value.ToString();

                if (dgvProductos.Columns[e.ColumnIndex].Name == "Ver")
                {
                    MessageBox.Show($"Ver detalles del producto ID {idProducto}");
                }
                else if (dgvProductos.Columns[e.ColumnIndex].Name == "Editar")
                {
                    MessageBox.Show($"Editar producto ID {idProducto}");
                }
                else if (dgvProductos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show($"Producto ID {idProducto} eliminado.");
                    }
                }
            }
        }


        private void ConfigurarDataGridView()
        {
            if (!dgvProductos.Columns.Contains("Opciones"))
            {
                DataGridViewButtonColumn btn_Editar = new DataGridViewButtonColumn();
                btn_Editar.Text = "Editar";
                dgvProductos.Columns.Add(btn_Editar);
                btn_Editar.UseColumnTextForButtonValue = true;


                DataGridViewImageColumn colEliminar = new DataGridViewImageColumn();
                colEliminar.Image = Image.FromStream(new MemoryStream(Properties.Resources.delete));
                colEliminar.Name = "Eliminar";
                dgvProductos.Columns.Add(colEliminar);
            }


        }


 


        //private void btnAplicarFiltros_Click(object sender, EventArgs e)
        //{
        //    // Lógica para aplicar filtros
        //    string categoria = cmbCategoria.Text;
        //    bool stockBajo = chkStockBajo.Checked;
        //    string rangoPrecio = txtRangoPrecio.Text;

        //    // Aquí puedes filtrar los datos en el DataGridView
        //    MessageBox.Show("Filtros aplicados: " + categoria + ", " + stockBajo + ", " + rangoPrecio);
        //}



        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.AutoScroll = false;
        }




        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Verificar si el DataGridView está vinculado a un DataTable
            if (dgvProductos.DataSource is DataTable dataTable)
            {
                try
                {
                    // Crear nueva fila
                    DataRow nuevaFila = dataTable.NewRow();

                    // Establecer valores (puedes usar valores por defecto o mostrar un formulario)
                    nuevaFila["nombre_producto"] = "Nuevo Producto";
                    nuevaFila["descripcion"] = "";
                    nuevaFila["precio_venta"] = 0;
                    nuevaFila["stock"] = 0;
                    // Agregar la fila al DataTable
                    dataTable.Rows.Add(nuevaFila);

                    // Opcional: Posicionarse en la nueva fila
                    dgvProductos.CurrentCell = dgvProductos.Rows[dataTable.Rows.Count - 1].Cells[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar producto: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El DataGridView no está vinculado a un DataTable válido");
            }
        }

        private void dgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0)
            //{
            //    MessageBox.Show("Abrir formulario para editar producto");
            //}

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                MessageBox.Show("Abrir formulario para PAPA producto");
            }

        }
    }
}
