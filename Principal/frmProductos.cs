using System.Data;
using System.Diagnostics;
using Logica;



namespace Principal
{
    public partial class frmProductos : Form
    {
        private ProductoL productoL = new ProductoL();
        private UsuarioL usuarioL = new UsuarioL();
        private bool modoEdicion = false;
        private DataGridViewRow filaEditable = null;
        private DataTable tablaOriginal;
        private string datos = null;
        public BindingSource bindingSource = null;


        public frmProductos()
        {
            InitializeComponent();
            bindingSource = new BindingSource();

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {


        }

        private void CargarDatos()
        {
            try
            {
                DataTable datosTabla;

                if (datos == "productos")
                {
                    datosTabla = productoL.ObtenerProductosL();
                }
                else if (datos == "usuarios")
                {
                    datosTabla = usuarioL.ObtenerUsuariosL();
                }
                else
                {
                    throw new Exception("Tipo de datos no reconocido.");
                }

                tablaOriginal = datosTabla.Copy();
                bindingSource.DataSource = datosTabla;
                dgvDatos.DataSource = bindingSource;

                if (datos == "productos")
                {
                    dgvDatos.Columns[0].DisplayIndex = 7;
                    dgvDatos.Columns[1].DisplayIndex = 8;
                    dgvDatos.Columns[2].DisplayIndex = 0;
                    dgvDatos.Columns[3].DisplayIndex = 1;
                    dgvDatos.Columns[4].DisplayIndex = 2;
                    dgvDatos.Columns[5].DisplayIndex = 3;
                    dgvDatos.Columns[6].DisplayIndex = 4;
                    dgvDatos.Columns[7].DisplayIndex = 5;
                    dgvDatos.Columns[8].DisplayIndex = 6;
                }
                else if (datos == "usuarios")
                {
                    dgvDatos.Columns["ID"].DisplayIndex = 0;
                    dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                    dgvDatos.Columns["Apellido"].DisplayIndex = 2;
                    dgvDatos.Columns["Correo"].DisplayIndex = 3;
                    dgvDatos.Columns["Contraseña"].DisplayIndex = 4;
                    dgvDatos.Columns["Rol"].DisplayIndex = 5;
                    dgvDatos.Columns["btnEditar"].DisplayIndex = 6;
                    dgvDatos.Columns["btnEliminar"].DisplayIndex = 7;
                }

                foreach (DataGridViewColumn col in dgvDatos.Columns)
                {
                    col.ReadOnly = !(col is DataGridViewTextBoxColumn) ||
                                   col.Name == "btnEditar" ||
                                   col.Name == "btnEliminar";
                }
                dgvDatos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (datos == "productos")
                {
                    if (modoEdicion)
                        GuardarDatos();
                    else
                        AgregarNuevoDato();
                }
                else if (datos == "usuarios")
                {
                    if (modoEdicion)
                        GuardarDatos();
                    else
                        AgregarNuevoDato();
                }
                else
                {
                    MessageBox.Show("Tipo de datos desconocido. Verifique la selección.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarNuevoDato()
        {
            btnGuardar.Location = btnAgregar.Location;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            DataTable table = (DataTable)bindingSource.DataSource;
            DataRow newRow = table.NewRow();

            if (datos == "productos")
            {
                newRow["Nombre"] = string.Empty;
                newRow["Categoria"] = string.Empty;
                newRow["Descripcion"] = string.Empty;
                newRow["Precio"] = 0m;
                newRow["Stock"] = 0;
                newRow["Proveedor"] = string.Empty;
            }
            else if (datos == "usuarios")
            {
                newRow["Nombre"] = string.Empty;
                newRow["Apellido"] = string.Empty;
                newRow["Correo"] = string.Empty;
                newRow["Contraseña"] = string.Empty;
                newRow["Rol"] = string.Empty;
            }

            table.Rows.InsertAt(newRow, 0);
            bindingSource.Position = 0;

            modoEdicion = true;
            dgvDatos.ReadOnly = false;

            HabilitarEdicionFila(0);
            EnfocarPrimeraCeldaEditable();
        }

        private void GuardarDatos()
        {
            if (!ValidarDatos()) return;

            if (bindingSource.Current == null)
            {
                MessageBox.Show("No hay un registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView currentRow = (DataRowView)bindingSource.Current;

            try
            {
                if (datos == "productos")
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
                        int id = Convert.ToInt32(currentRow["ID"]);
                        productoL.EditarProductoL(id, nombre, categoria, descripcion, precio, stock, proveedor);
                        MessageBox.Show("Producto editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (datos == "usuarios")
                {
                    string correo = currentRow["Correo"]?.ToString() ?? string.Empty;
                    string nombre = currentRow["Nombre"]?.ToString() ?? string.Empty;
                    string apellido = currentRow["Apellido"]?.ToString() ?? string.Empty;
                    string contraseña = currentRow["Contraseña"]?.ToString() ?? string.Empty;
                    string rol = currentRow["Rol"]?.ToString() ?? string.Empty;

                    if (filaEditable == null || filaEditable.Index == 0)
                    {
                        usuarioL.AgregarUsuarioL(nombre, apellido, correo, contraseña, rol);
                        MessageBox.Show("Usuario agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = Convert.ToInt32(currentRow[0]);
                        usuarioL.EditarUsuarioL(id, nombre, apellido, correo, contraseña, rol);
                        MessageBox.Show("Usuario editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Debug.WriteLine(message: "Correo " + correo, "Contra " + contraseña);
                    }
                }

                modoEdicion = false;
                dgvDatos.ReadOnly = true;
                dgvDatos.ClearSelection();
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;

                CargarDatos();
            }
            catch (Exception ex)
            {
                string mensajeError = $"Error al guardar los datos: {ex.Message}\nTipo de excepción: {ex.GetType().Name}\nPila de llamadas: {ex.StackTrace}";
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidarDatos()
        {
            DataRowView currentRow = (DataRowView)bindingSource.Current;

            if (string.IsNullOrWhiteSpace(currentRow["Nombre"].ToString()))
            {
                MessageBox.Show("El nombre es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarCelda("Nombre");
                return false;
            }

            if (datos == "productos")
            {
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
            }
            else if (datos == "usuarios")
            {
                if (string.IsNullOrWhiteSpace(currentRow["Correo"].ToString()))
                {
                    MessageBox.Show("El correo es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnfocarCelda("Correo");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(currentRow["Contraseña"].ToString()))
                {
                    MessageBox.Show("La contraseña es requerida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EnfocarCelda("Contraseña");
                    return false;
                }
            }

            return true;
        }

        private void EnfocarCelda(string nombreColumna)
        {
            var columna = dgvDatos.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == nombreColumna);

            if (columna != null && dgvDatos.CurrentRow != null)
            {
                dgvDatos.CurrentCell = dgvDatos.CurrentRow.Cells[columna.Index];
                dgvDatos.BeginEdit(true);
            }
        }

        private void HabilitarEdicionFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvDatos.Rows.Count)
                return;

            foreach (DataGridViewRow row in dgvDatos.Rows)
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

            filaEditable = dgvDatos.Rows[rowIndex];
            filaEditable.DefaultCellStyle.BackColor = Color.LightYellow;

            foreach (DataGridViewCell cell in filaEditable.Cells)
            {
                if (cell.OwningColumn is DataGridViewTextBoxColumn && cell.ColumnIndex != 0)
                {
                    cell.ReadOnly = false;
                }
            }

            dgvDatos.BeginEdit(true);
        }



        private void EnfocarPrimeraCeldaEditable()
        {
            if (dgvDatos.Rows.Count == 0) return;

            var primeraEditable = dgvDatos.Rows[0].Cells
                .OfType<DataGridViewCell>()
                .FirstOrDefault(c => !c.ReadOnly && c.OwningColumn.Visible);

            if (primeraEditable != null)
            {
                dgvDatos.CurrentCell = primeraEditable;
                dgvDatos.BeginEdit(true);
            }
        }


        private void EliminarDato(int rowIndex)
        {
            if (rowIndex < 0) return;

            string? idProducto = dgvDatos.Rows[rowIndex].Cells["ID"].Value?.ToString();
            string? correoUsuario = dgvDatos.Rows[rowIndex].Cells["correo"].Value?.ToString();
            string tipo = datos == "productos" ? "producto" : "usuario";

            string identificador = datos == "productos" ? idProducto ?? "desconocido" : correoUsuario ?? "desconocido";

            var confirmResult = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar el {tipo} '{identificador}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (datos == "productos")
                    {
                        if (idProducto != null) productoL.EliminarProductoL(idProducto);
                        else throw new Exception("El ID del producto es nulo.");
                    }
                    else
                    {
                        if (correoUsuario != null) usuarioL.EliminarUsuarioL(correoUsuario);
                        else throw new Exception("El correo del usuario es nulo.");
                    }

                    MessageBox.Show($"{tipo} eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el {tipo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void EditarDato(int rowIndex)
        {
            if (modoEdicion)
            {
                MessageBox.Show("Ya hay una fila en modo edición. Guarda los cambios antes de editar otra fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDatos.CurrentRow != null)
            {
                filaEditable = dgvDatos.CurrentRow;
                modoEdicion = true;
                HabilitarEdicionFila(filaEditable.Index);
            }

            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            btnGuardar.Location = btnAgregar.Location;
        }


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDatos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string nombreBoton = dgvDatos.Columns[e.ColumnIndex].Name;

                if (nombreBoton == "btnEditar")
                {
                    DataGridViewButtonCell boton = (DataGridViewButtonCell)dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    if (boton.Value.ToString() == "Editar")
                    {
                        EditarDato(e.RowIndex);
                    }

                }
                else if (nombreBoton == "btnEliminar")
                {
                    EliminarDato(e.RowIndex);
                }
            }
        }



        private void Cancelar()
        {
            if (!modoEdicion || filaEditable == null)
                return;

            DataTable table = (DataTable)bindingSource.DataSource;
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
            dgvDatos.Refresh();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            Cancelar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();

        }

        private void linkLabelUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "usuarios";
            CargarDatos();
        }

        private void linkLabelProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "productos";
            CargarDatos();

        }

        private void linkLabelFacturas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


    }
}