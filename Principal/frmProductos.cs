using System.Data;
using System.Diagnostics;
using Logica;

namespace Principal
{
    public partial class frmProductos : Form
    {
        private ProductoL productoL = new ProductoL();
        private UsuarioL usuarioL = new UsuarioL();
        private FacturaL facturaL = new FacturaL();
        private CategoriaL categoriaL = new CategoriaL();
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
            if (GlobalVariables.Rol == "Administrador")
            {
                linkLabelUsuarios.Visible = true;
            }
            else
            {
                linkLabelUsuarios.Visible = false;
            }

        }

        private void SetButtonText(string text)
        {
            if (dgvDatos.Columns["btnEditar"] is DataGridViewButtonColumn btnColumn)
            {
                btnColumn.UseColumnTextForButtonValue = true;
                btnColumn.Text = text;
            }
        }
        private void CargarDatos()
        {
            try
            {
                DataTable datosTabla;



                switch (datos)
                {
                    case "productos":
                        datosTabla = productoL.ObtenerProductosL();
                        SetButtonText("Editar");

                        break;

                    case "usuarios":
                        datosTabla = usuarioL.ObtenerUsuariosL();
                        SetButtonText("Editar");

                        break;

                    case "facturas":
                        datosTabla = facturaL.ObtenerFacturaL();
                        break;

                    case "proveedores":
                        datosTabla = usuarioL.ObtenerProveedoresL();
                        SetButtonText("Editar");

                        break;

                    case "categorias":
                        datosTabla = categoriaL.ObtenerCategoriasL();
                        SetButtonText("Editar");

                        break;

                    default:
                        throw new Exception("Tipo de datos no reconocido.");
                }


                tablaOriginal = datosTabla.Copy();
                bindingSource.DataSource = datosTabla;
                dgvDatos.DataSource = bindingSource;

                switch (datos)
                {
                    case "productos":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                        dgvDatos.Columns["Categoria"].DisplayIndex = 2;
                        dgvDatos.Columns["Descripcion"].DisplayIndex = 3;
                        dgvDatos.Columns["Precio"].DisplayIndex = 4;
                        dgvDatos.Columns["Stock"].DisplayIndex = 5;
                        dgvDatos.Columns["Proveedor"].DisplayIndex = 6;
                        dgvDatos.Columns["Fecha"].DisplayIndex = 7;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 8;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 9;
                        break;

                    case "usuarios":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                        dgvDatos.Columns["Apellido"].DisplayIndex = 2;
                        dgvDatos.Columns["Correo"].DisplayIndex = 3;
                        dgvDatos.Columns["Contraseña"].DisplayIndex = 4;
                        dgvDatos.Columns["Rol"].DisplayIndex = 5;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 6;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 7;
                        break;

                    case "facturas":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Tipo"].DisplayIndex = 1;
                        dgvDatos.Columns["Empleado"].DisplayIndex = 2;
                        dgvDatos.Columns["Cliente"].DisplayIndex = 3;
                        dgvDatos.Columns["Proveedor"].DisplayIndex = 4;
                        dgvDatos.Columns["Fecha"].DisplayIndex = 5;
                        dgvDatos.Columns["Total"].DisplayIndex = 6;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 7;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 8;
                        break;

                    case "detallesFactura":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Factura"].DisplayIndex = 1;
                        dgvDatos.Columns["Producto"].DisplayIndex = 2;
                        dgvDatos.Columns["Teléfono"].DisplayIndex = 3;
                        dgvDatos.Columns["Direccion"].DisplayIndex = 4;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 5;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 6;
                        break;

                    case "proveedores":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                        dgvDatos.Columns["Contacto"].DisplayIndex = 2;
                        dgvDatos.Columns["Teléfono"].DisplayIndex = 3;
                        dgvDatos.Columns["Direccion"].DisplayIndex = 4;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 5;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 6;
                        break;

                    case "categorias":
                        dgvDatos.Columns["ID"].DisplayIndex = 0;
                        dgvDatos.Columns["Nombre"].DisplayIndex = 1;
                        dgvDatos.Columns["Descripcion"].DisplayIndex = 2;
                        dgvDatos.Columns["btnEditar"].DisplayIndex = 3;
                        dgvDatos.Columns["btnEliminar"].DisplayIndex = 4;
                        break;
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
            if (datos == "facturas")
            {
                GlobalVariables.TipoFactura = "Compra";
                frmFactura frmFactura = new frmFactura();
                this.Hide();
                frmFactura.ShowDialog();
                this.Show();


            }
            if (modoEdicion && datos != "facturas")
                GuardarDatos();
            else if (datos != "facturas")
            {
                AgregarNuevoDato();
            }

        }

        private void AgregarNuevoDato()
        {
            btnGuardar.Location = btnAgregar.Location;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnAgregar.Visible = false;

            DataTable table = (DataTable)bindingSource.DataSource;
            DataRow newRow = table.NewRow();

            switch (datos)
            {
                case "productos":
                    newRow["Nombre"] = string.Empty;
                    newRow["Categoria"] = string.Empty;
                    newRow["Descripcion"] = string.Empty;
                    newRow["Precio"] = 0m;
                    newRow["Stock"] = 0;
                    newRow["Proveedor"] = string.Empty;
                    break;

                case "usuarios":
                    newRow["Nombre"] = string.Empty;
                    newRow["Apellido"] = string.Empty;
                    newRow["Correo"] = string.Empty;
                    newRow["Contraseña"] = string.Empty;
                    newRow["Rol"] = string.Empty;
                    break;

                case "proveedores":
                    newRow["Nombre"] = string.Empty;
                    newRow["Contacto"] = string.Empty;
                    newRow["Teléfono"] = string.Empty;
                    newRow["Direccion"] = string.Empty;
                    break;

                case "categorias":
                    newRow["Nombre"] = string.Empty;
                    newRow["Descripcion"] = string.Empty;
                    break;
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
                switch (datos)
                {
                    case "productos":
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
                            break;
                        }

                    case "usuarios":
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
                                Debug.WriteLine("Correo " + correo, "Contra " + contraseña);
                            }
                            break;
                        }

                    case "proveedores":
                        {
                            string nombre = currentRow["Nombre"]?.ToString() ?? string.Empty;
                            string contacto = currentRow["Contacto"]?.ToString() ?? string.Empty;
                            string telefono = currentRow["Teléfono"]?.ToString() ?? string.Empty;
                            string direccion = currentRow["Direccion"]?.ToString() ?? string.Empty;

                            if (filaEditable == null || filaEditable.Index == 0)
                            {
                                usuarioL.AgregarProveedorL(nombre, contacto, telefono, direccion);
                                MessageBox.Show("Proveedor agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int id = Convert.ToInt32(currentRow[0]);
                                usuarioL.EditarProveedorL(id, nombre, contacto, telefono, direccion);
                                MessageBox.Show("Proveedor editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }

                    case "categorias":
                        {
                            string nombre = currentRow["Nombre"]?.ToString() ?? string.Empty;
                            string descripcion = currentRow["Descripcion"]?.ToString() ?? string.Empty;

                            if (filaEditable == null || filaEditable.Index == 0)
                            {
                                categoriaL.AgregarCategoriaL(nombre, descripcion);
                                MessageBox.Show("Categoría agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int id = Convert.ToInt32(currentRow["ID"]);
                                categoriaL.EditarCategoriaL(id, nombre, descripcion);
                                MessageBox.Show("Categoría editada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;

                        }

                }

                modoEdicion = false;
                dgvDatos.ReadOnly = true;
                dgvDatos.ClearSelection();
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                btnAgregar.Visible = true;

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

            string tipo = datos;
            string? identificador = ObtenerIdentificador(rowIndex, tipo);

            if (string.IsNullOrEmpty(identificador))
            {
                MessageBox.Show($"Identificador no válido para {tipo}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                    switch (tipo)
                    {
                        case "productos":
                            productoL.EliminarProductoL(identificador);
                            break;
                        case "usuarios":
                            usuarioL.EliminarUsuarioL(identificador);
                            break;
                        case "proveedores":
                            usuarioL.EliminarProveedorL(identificador);
                            break;
                        case "categorias":
                            categoriaL.EliminarCategoriaL(identificador);
                            break;
                        case "facturas":
                            facturaL.EliminarFacturaL(identificador);
                            break;
                        default:
                            throw new Exception($"No se encontró el tipo '{tipo}' para eliminar.");
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



        private string? ObtenerIdentificador(int rowIndex, string tipo)
        {
            switch (tipo)
            {
                case "productos":
                case "proveedores":
                case "categorias":
                    return dgvDatos.Rows[rowIndex].Cells["nombre"].Value?.ToString();

                case "usuarios":
                    return dgvDatos.Rows[rowIndex].Cells["correo"].Value?.ToString();

                case "facturas":
                    return dgvDatos.Rows[rowIndex].Cells["Id"].Value?.ToString();

                default:
                    return null;
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
            btnAgregar.Visible = false;
            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            btnGuardar.Location = btnAgregar.Location;
            dgvDatos.ReadOnly = false;
        }



        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDatos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string nombreBoton = dgvDatos.Columns[e.ColumnIndex].Name;

                if (nombreBoton == "btnEditar")
                {
                    if (datos == "facturas")
                    {
                        int idFactura = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["ID"].Value);
                        datos = "detallesFactura";
                        bindingSource.DataSource = facturaL.ObtenerDetallesFacturaL(idFactura);
                        dgvDatos.DataSource = bindingSource;
                        SetButtonText("Editar");  
                    }
                    else
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
            btnAgregar.Visible = true;
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
            btnAgregar.Text = "Agregar Usuario";
            btnFacturaVenta.Visible = false;
            btnAgregar.Visible = true;
            CargarDatos();
        }

        private void linkLabelProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "productos";
            btnAgregar.Text = "Agregar Producto";
            btnFacturaVenta.Visible = false;
            btnAgregar.Visible = true;
            CargarDatos();

        }


        private void linkLabelFacturas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "facturas";

            btnAgregar.Text = "Agregar Factura Compra";
            btnAgregar.Visible = true;
            btnFacturaVenta.Visible = true;
            btnAgregar.AutoSize = true;
            btnAgregar.Location = new Point(1070, 127);

            if (dgvDatos.Columns["btnEditar"] is DataGridViewButtonColumn btnColumn)
            {
                btnColumn.HeaderText = "Acción";
                btnColumn.UseColumnTextForButtonValue = true;
                btnColumn.Text = "Ver Factura";
            }

            CargarDatos();
        }

        private void lbProv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "proveedores";
            btnAgregar.Text = "Agregar Provedor";
            btnFacturaVenta.Visible = false;
            btnAgregar.Visible = true;
            CargarDatos();
        }

        private void linkLabelCategorias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datos = "categorias";
            btnAgregar.Text = "Agregar Categoria";
            btnFacturaVenta.Visible = false;
            btnAgregar.Visible = true;
            CargarDatos();
        }

        private void btnFacturaVenta_Click(object sender, EventArgs e)
        {
            if (datos == "facturas")
            {
                GlobalVariables.TipoFactura = "Venta";
                frmFactura frmFactura = new frmFactura();
                this.Hide();
                frmFactura.ShowDialog();
                this.Show();

            }

        }


    }
}