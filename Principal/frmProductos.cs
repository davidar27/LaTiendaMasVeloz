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
    public partial class frmProductos : Form
    {
        private ProductoL productoL = new ProductoL();
        private bool modoEdicion = false;
        private DataGridViewRow filaEditable = null;
        private DataTable tablaOriginal;


        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

        }

        private void CargarProductos()
        {
            try
            {
                DataTable products = productoL.ObtenerProductosL();
                tablaOriginal = products.Copy();
                bindingSource1.DataSource = products;
                dgvProductos.DataSource = bindingSource1;

                foreach (DataGridViewColumn col in dgvProductos.Columns)
                {
                    col.ReadOnly = !(col is DataGridViewTextBoxColumn) ||
                                   col.Name == "btnEditar" ||
                                   col.Name == "btnEliminar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicion)
                {
                    AgregarNuevoProducto();
                }
                else
                {
                    GuardarProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarNuevoProducto()
        {

            btnGuardar.Location = btnAgregar.Location;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            DataTable table = (DataTable)bindingSource1.DataSource;
            DataRow newRow = table.NewRow();

            newRow["Nombre"] = string.Empty;
            newRow["Categoria"] = string.Empty;
            newRow["Descripcion"] = string.Empty;
            newRow["Precio"] = 0m;
            newRow["Stock"] = 0;
            newRow["Proveedor"] = string.Empty;

            table.Rows.InsertAt(newRow, 0);
            bindingSource1.Position = 0;

            modoEdicion = true;
            dgvProductos.ReadOnly = false;

            HabilitarEdicionFila(0);
            EnfocarPrimeraCeldaEditable();
        }

        private void GuardarProducto()
        {
            if (!ValidarDatos()) return;

            if (bindingSource1.Current == null)
            {
                MessageBox.Show("No hay un producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView currentRow = (DataRowView)bindingSource1.Current;

            try
            {
                string nombre = currentRow["Nombre"]?.ToString() ?? string.Empty;
                string categoria = currentRow["Categoria"]?.ToString() ?? string.Empty;
                string descripcion = currentRow["Descripcion"]?.ToString() ?? string.Empty;
                decimal precio = Convert.ToDecimal(currentRow["Precio"]);
                int stock = Convert.ToInt32(currentRow["Stock"]);
                string proveedor = currentRow["Proveedor"]?.ToString() ?? string.Empty;

                if (filaEditable == null || filaEditable.Index == 0)
                {
                    productoL.AgregarProductoL(nombre, categoria, descripcion, precio, stock, proveedor);
                    MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int id = Convert.ToInt32(currentRow["Id"]);
                    productoL.EditarProductoL(id, nombre, categoria, descripcion, precio, stock, proveedor);
                    MessageBox.Show("Producto editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                modoEdicion = false;
                dgvProductos.ReadOnly = true;
                dgvProductos.ClearSelection();
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;

                CargarProductos();
            }
            catch (Exception ex)
            {
                string mensajeError = $"Error al guardar el producto: {ex.Message}\nTipo de excepción: {ex.GetType().Name}\nPila de llamadas: {ex.StackTrace}";
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidarDatos()
        {
            DataRowView currentRow = (DataRowView)bindingSource1.Current;

            if (string.IsNullOrWhiteSpace(currentRow["Nombre"].ToString()))
            {
                MessageBox.Show("El nombre del producto es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarCelda("Nombre");
                return false;
            }

            if (!decimal.TryParse(currentRow["Precio"].ToString(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un valor mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarCelda("Precio");
                return false;
            }

            if (!int.TryParse(currentRow["Stock"].ToString(), out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número positivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarCelda("Stock");
                return false;
            }

            return true;
        }

        private void EnfocarCelda(string nombreColumna)
        {
            var columna = dgvProductos.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == nombreColumna);

            if (columna != null && dgvProductos.CurrentRow != null)
            {
                dgvProductos.CurrentCell = dgvProductos.CurrentRow.Cells[columna.Index];
                dgvProductos.BeginEdit(true);
            }
        }

        private void HabilitarEdicionFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvProductos.Rows.Count)
                return;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn is DataGridViewTextBoxColumn)
                    {
                        cell.ReadOnly = true;
                    }
                }
                row.DefaultCellStyle.BackColor = SystemColors.Control;
            }

            filaEditable = dgvProductos.Rows[rowIndex];
            filaEditable.DefaultCellStyle.BackColor = Color.LightYellow;

            foreach (DataGridViewCell cell in filaEditable.Cells)
            {
                if (cell.OwningColumn is DataGridViewTextBoxColumn && cell.ColumnIndex != 0)
                {
                    cell.ReadOnly = false;
                }
            }

            dgvProductos.BeginEdit(true);
        }



        private void EnfocarPrimeraCeldaEditable()
        {
            if (dgvProductos.Rows.Count == 0) return;

            var primeraEditable = dgvProductos.Rows[0].Cells
                .OfType<DataGridViewCell>()
                .FirstOrDefault(c => !c.ReadOnly && c.OwningColumn.Visible);

            if (primeraEditable != null)
            {
                dgvProductos.CurrentCell = primeraEditable;
                dgvProductos.BeginEdit(true);
            }
        }



        private void EliminarProducto(int rowIndex)
        {
            if (rowIndex < 0) return;

            string? nombre = dgvProductos.Rows[rowIndex].Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("No se pudo obtener el nombre del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto '{nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    productoL.EliminarProductoL(nombre);
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EditarProducto(int rowIndex)
        {

            if (modoEdicion)
            {

                MessageBox.Show("Ya hay una fila en modo edición. Guarda los cambios antes de editar otra fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
                
            
            if (dgvProductos.CurrentRow != null)
            {
                filaEditable = dgvProductos.CurrentRow;
                modoEdicion = true;
                HabilitarEdicionFila(filaEditable.Index);
            }
            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            btnGuardar.Location = btnAgregar.Location;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string nombreBoton = dgvProductos.Columns[e.ColumnIndex].Name;

                if (nombreBoton == "btnEditar")
                {
                    DataGridViewButtonCell boton = (DataGridViewButtonCell)dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    if (boton.Value.ToString() == "Editar")
                    {
                        EditarProducto(e.RowIndex);
                    }
                   
                }
                else if (nombreBoton == "btnEliminar")
                {
                    EliminarProducto(e.RowIndex);
                }
            }
        }

     

        private void Cancelar()
        {
            if (!modoEdicion || filaEditable == null)
                return;

            DataTable table = (DataTable)bindingSource1.DataSource;
            table.RejectChanges();

            foreach (DataGridViewCell cell in filaEditable.Cells)
            {
                if (cell.OwningColumn is DataGridViewTextBoxColumn)
                {
                    cell.ReadOnly = true;
                }
            }

            filaEditable.DefaultCellStyle.BackColor = SystemColors.Control;
            filaEditable = null;
            modoEdicion = false;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            dgvProductos.Refresh();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            Cancelar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProducto();

        }
    }
}
