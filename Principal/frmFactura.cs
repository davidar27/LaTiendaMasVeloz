using System.Diagnostics;
using Logica;
using Logica.DTO;

namespace Principal
{
    public partial class frmFactura : Form
    {

        private ProductoL productoL = new ProductoL();
        private FacturaL facturaL = new FacturaL();
        private UsuarioL usuarioL = new UsuarioL();
        private string textoAnteriorBtn = string.Empty;
        private int idFactura;
        public bool EsEdicion { get; set; } = false;
        public int IdFacturaEditar { get; set; }









        public frmFactura()
        {
            InitializeComponent();
            this.idFactura = idFactura;

            //CargarFactura(idFactura);
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            CargarTipoFactura();
            ActualizarCampos();


            cbxProductos.DisplayMember = "Nombre";
            cbxProductos.ValueMember = "Id";
            cbxProductos.Format += (sender, e) =>
            {
                var type = e.ListItem.GetType();
                var id = type.GetProperty("Id")?.GetValue(e.ListItem);
                var nombre = type.GetProperty("Nombre")?.GetValue(e.ListItem);
                var precio = type.GetProperty("Precio")?.GetValue(e.ListItem);

                e.Value = $"{id} - {nombre} - ${precio}";
            };
            cbxProductos.SelectedIndexChanged += (sender, e) => ActualizarEstadoBoton();



            var empleados = usuarioL.ObtenerEmpleadosL();
            cbxEmpleado.DataSource = empleados;
            cbxEmpleado.DisplayMember = "NombreCompleto";
            cbxEmpleado.ValueMember = "Id";
            cbxEmpleado.Format += (sender, e) =>
            {
                var type = e.ListItem.GetType();
                var Id = type.GetProperty("Id")?.GetValue(e.ListItem);
                var NombreCompleto = type.GetProperty("NombreCompleto")?.GetValue(e.ListItem);


                e.Value = $"{Id} - {NombreCompleto}";
            };




            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            ConfigurarPanelRegistro();
        }


        private void CargarTipoFactura()
        {

            //if (EsEdicion)
            //{
            //    //CargarFacturaExistente();
            //    return;
            //}

            if (GlobalVariables.TipoFactura == "Venta")
            {
                var clientes = usuarioL.ObtenerClientesL();
                cbxEntidad.DataSource = clientes;
                cbxEntidad.DisplayMember = "NombreCompleto";
                cbxEntidad.ValueMember = "Id";
                cbxEntidad.Format += (sender, e) =>
                {
                    var type = e.ListItem.GetType();
                    var Id = type.GetProperty("Id")?.GetValue(e.ListItem);
                    var NombreCompleto = type.GetProperty("NombreCompleto")?.GetValue(e.ListItem);


                    e.Value = $"{Id} - {NombreCompleto}";
                };
                var productos = facturaL.ObtenerListaProductos();
                cbxProductos.DataSource = productos;
                btnRegistrarProducto.Visible = false;

            }
            else if (GlobalVariables.TipoFactura == "Compra")
            {
                var proveedores = usuarioL.ListaProveedoresL();
                cbxEntidad.DataSource = proveedores;
                cbxEntidad.DisplayMember = "Nombre";
                cbxEntidad.ValueMember = "Id";
                cbxEntidad.Format += (sender, e) =>
                {
                    var type = e.ListItem.GetType();
                    var Id = type.GetProperty("Id")?.GetValue(e.ListItem);
                    var Nombre = type.GetProperty("Nombre")?.GetValue(e.ListItem);

                    e.Value = $"{Id} - {Nombre}";
                };

                cbxEntidad.SelectedIndexChanged += (sender, e) =>
                {
                    if (cbxEntidad.SelectedItem != null)
                    {
                        try
                        {
                            var type = cbxEntidad.SelectedItem.GetType();
                            var idProp = type.GetProperty("Id");

                            if (idProp != null)
                            {
                                var proveedorId = idProp.GetValue(cbxEntidad.SelectedItem).ToString();
                                var productosFiltrados = facturaL.ObtenerProductosPorProveedorL(proveedorId);
                                cbxProductos.DataSource = productosFiltrados;


                                ActualizarEstadoBoton();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar productos: {ex.Message}");
                        }
                    }
                };



                lbNTipo.Text = "Proveedor";
                btnMostReg.Text = "Registrar Nuevo Proveedor";
                btnCrearRegistro.Text = "Crear Proveedor";
            }
            else
            {
                throw new Exception("Tipo de datos no reconocido.");
            }
        }
        private void ActualizarTablaFactura()
        {
            dgvFacturaProductos.DataSource = null;
            dgvFacturaProductos.DataSource = facturaL.ObtenerProductosFactura();
            ActualizarEstadoBoton();

        }

        //private void CargarFacturaExistente()
        //{
        //    DetalleFacturaDTO factura = facturaL.ObtenerFacturaPorIdL(IdFacturaEditar);

        //    GlobalVariables.TipoFactura = factura.; // Asegúrate que venga con esto
        //    // Y ahora cargas el combo y seleccionas el cliente o proveedor según el tipo
        //    if (factura.Tipo == "Venta")
        //    {
        //        List<ClienteDTO> clientes = usuarioL.ObtenerClientesL();
        //        cbxEntidad.DataSource = clientes;
        //        cbxEntidad.DisplayMember = "NombreCompleto";
        //        cbxEntidad.ValueMember = "Id";
        //        cbxEntidad.SelectedValue = factura.IdCliente;
        //    }
        //    else if (factura.Tipo == "Compra")
        //    {
        //        List<ProveedorDTO> proveedores = usuarioL.ListaProveedoresL();
        //        cbxEntidad.DataSource = proveedores;
        //        cbxEntidad.DisplayMember = "Nombre";
        //        cbxEntidad.ValueMember = "Id";
        //        cbxEntidad.SelectedValue = factura.IdProveedor;
        //    }

        //    dgvFacturaProductos.DataSource = factura.IdDetalle;
        //}


        private void ActualizarEstadoBoton()
        {
            if (cbxProductos.SelectedItem == null)
            {
                btnAgregarProducto.Text = "Agregar";
                btnAgregarProducto.BackColor = Color.LightGray;
                btnAgregarProducto.Enabled = false;
                return;
            }

            var item = cbxProductos.SelectedItem;
            var type = item.GetType();
            var idProperty = type.GetProperty("Id");

            if (idProperty == null)
            {
                throw new InvalidOperationException("El objeto seleccionado no tiene propiedad 'Id'.");
            }

            int productoId = (int)idProperty.GetValue(item);

            bool productoExiste = facturaL.ProductoExisteEnFactura(productoId);

            btnAgregarProducto.Enabled = true;
            btnAgregarProducto.Text = productoExiste ? "Eliminar" : "Agregar";
            btnAgregarProducto.BackColor = productoExiste ? Color.LightCoral : Color.LightGreen;
        }





        private void ConfigurarPanelRegistro()
        {

            btnMostReg.Click += (s, e) =>
            {
                panelRegistro.Visible = !panelRegistro.Visible;
                if (panelRegistro.Visible) tbxNombre.Focus();
            };



            tbxNombre.TextChanged += ValidarCampos;
            tbxRegistro1.TextChanged += ValidarCampos;
            tbxRegistro2.TextChanged += ValidarCampos;
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = tbxNombre.Text.Trim();
                string registro1 = tbxRegistro1.Text.Trim();
                string registro2 = tbxRegistro2.Text.Trim();



                switch (btnCrearRegistro.Text)
                {
                    case "Crear Cliente":
                        if (!EsCorreoValido(registro2))
                        {
                            MessageBox.Show("Ingrese un correo válido", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        usuarioL.AgregarClienteL(nombre, registro1, registro2);
                        ActualizarLista();

                        MessageBox.Show("Cliente registrado con éxito", "Éxito",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarControles();
                        panelRegistro.Visible = false;
                        btnMostReg.Text = "Registrar Nuevo Cliente";
                        btnMostReg.BackColor = Color.LightGreen;

                        break;

                    case "Crear Proveedor":
                        if (string.IsNullOrWhiteSpace(registro1) || string.IsNullOrWhiteSpace(registro2))
                        {
                            MessageBox.Show("Complete todos los campos del proveedor", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string direccion = "none";

                        int idProveedor = usuarioL.AgregarProveedorL(nombre, registro1, registro2, direccion);
                        ActualizarLista();
                        cbxEntidad.SelectedValue = idProveedor;


                        MessageBox.Show("Proveedor registrado con éxito", "Éxito",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles();
                        panelRegistro.Visible = false;
                        btnRegistrarProducto.Location = btnMostReg.Location;
                        btnMostReg.Visible = false;
                        btnRegistrarProducto.Text = "Registrar Nuevo Producto";
                        btnMostReg.BackColor = Color.LightGreen;
                        break;

                    case "Crear Producto":
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(registro1) || string.IsNullOrWhiteSpace(registro2))
                                {
                                    MessageBox.Show("Complete todos los campos del producto", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (!decimal.TryParse(registro1, out decimal precio))
                                {
                                    MessageBox.Show("Ingrese un precio válido", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (!int.TryParse(registro2, out int stock))
                                {
                                    MessageBox.Show("Ingrese un valor de stock válido", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (cbxEntidad.SelectedValue == null)
                                {
                                    MessageBox.Show("Seleccione un proveedor", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string proveedor = cbxEntidad.SelectedValue.ToString();
                               

                                if (precio <= 0)
                                {
                                    MessageBox.Show("El precio debe ser mayor a cero", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (stock < 0)
                                {
                                    MessageBox.Show("El stock no puede ser negativo", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                int idProducto = productoL.AgregarProductoBasicoL(nombre, precio, stock, proveedor);

                                ActualizarLista();
                                cbxProductos.SelectedValue = idProducto;

                                LimpiarControles();
                                panelRegistro.Visible = false;
                                btnRegistrarProducto.Text = "Registrar Nuevo Producto";                                
                                btnRegistrarProducto.BackColor = Color.LightGreen;

                                if (nudCantidad.Maximum < stock)
                                    nudCantidad.Maximum = stock;
                                nudCantidad.Value = stock;

                                MessageBox.Show("Producto registrado con éxito", "Éxito",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al crear el producto: {ex.Message}", "Error",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Acción no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidarCampos(object sender, EventArgs e)
        {
            btnCrearRegistro.Enabled =
                !string.IsNullOrWhiteSpace(tbxNombre.Text) &&
                !string.IsNullOrWhiteSpace(tbxRegistro1.Text) &&
                !string.IsNullOrWhiteSpace(tbxRegistro2.Text);
        }

        private bool EsCorreoValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LimpiarControles()
        {
            tbxNombre.Clear();
            tbxRegistro1.Clear();
            tbxRegistro2.Clear();
            tbxNombre.Focus();
        }


        private void ActualizarCampos()
        {
            tbxNombre.Text = string.Empty;
            tbxRegistro1.Text = string.Empty;
            tbxRegistro2.Text = string.Empty;
            tbxNombre.Focus();




            switch (btnMostReg.Text.Trim())
            {
                case "Registrar Nuevo Cliente":
                    ConfigurarCampos(
                        "Ingrese el nombre del cliente",
                        "Ingrese el apellido del cliente",
                        "Ingrese el correo del cliente");
                    break;

                case "Registrar Nuevo Proveedor":
                    ConfigurarCampos(
                        "Ingrese el nombre del proveedor",
                        "Ingrese el contacto del proveedor",
                        "Ingrese el teléfono del proveedor");
                    break;

                default:
                    MessageBox.Show($"Texto del botón no reconocido: '{btnMostReg.Text}'",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ConfigurarCampos(string placeholderNombre,
                                    string placeholderRegistro1,
                                    string placeholderRegistro2)
        {
            tbxNombre.PlaceholderText = placeholderNombre;
            tbxRegistro1.PlaceholderText = placeholderRegistro1;
            tbxRegistro2.PlaceholderText = placeholderRegistro2;
        }


        private void ActualizarLista()
        {
            try
            {
                switch (btnCrearRegistro.Text)
                {
                    case "Crear Cliente":
                        var clientes = usuarioL.ObtenerClientesL();
                        cbxEntidad.DataSource = clientes;
                        break;

                    case "Crear Proveedor":
                        var proveedores = usuarioL.ListaProveedoresL();
                        cbxEntidad.DataSource = proveedores;
                        break;

                    case "Crear Producto":
                        var productos = facturaL.ObtenerListaProductos();
                        cbxProductos.DataSource = productos;
                        break;

                    default:
                        MessageBox.Show("No se puede actualizar la lista, tipo de registro desconocido", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar lista: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnMostReg_Click(object sender, EventArgs e)
        {


            switch (btnMostReg.Text)
            {
                case "Registrar Nuevo Cliente":
                case "Registrar Nuevo Proveedor":
                    textoAnteriorBtn = btnMostReg.Text;
                    btnMostReg.Text = "Cancelar";
                    btnMostReg.BackColor = Color.LightCoral;
                    panelRegistro.Visible = false;
                    tbxNombre.Focus();
                    break;

                case "Cancelar":
                    if (MessageBox.Show("¿Desea cancelar el registro?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnMostReg.Text = textoAnteriorBtn;
                        btnMostReg.BackColor = Color.LightGreen;
                        panelRegistro.Visible = true;
                        LimpiarControles();
                    }
                    break;
            }

     

        }


        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoFactura = GlobalVariables.TipoFactura;
                int? idCliente = tipoFactura == "Venta"
                                 ? (int?)Convert.ToInt32(cbxEntidad.SelectedValue)
                                 : null;
                int idEmpleado = Convert.ToInt32(cbxEmpleado.SelectedValue);

                int idFactura = facturaL.CrearFacturaL(tipoFactura, idCliente, idEmpleado);

                foreach (DataGridViewRow row in dgvFacturaProductos.Rows)
                {
                    if (row.IsNewRow) continue;
                    int idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[3].Value);
                    facturaL.AgregarDetalleFacturaL(idFactura, idProducto, cantidad);
                }

                MessageBox.Show($"Factura #{idFactura} creada exitosamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear factura: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbxProductos.SelectedItem == null) return;

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var type = cbxProductos.SelectedItem.GetType();
                var idProp = type.GetProperty("Id");
                var nombreProp = type.GetProperty("Nombre");
                var precioProp = type.GetProperty("Precio");

                if (idProp == null || nombreProp == null || precioProp == null)
                {
                    MessageBox.Show("El objeto producto no tiene la estructura esperada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = (int)idProp.GetValue(cbxProductos.SelectedItem);
                string nombre = nombreProp.GetValue(cbxProductos.SelectedItem)?.ToString();
                decimal precio = precioProp.GetValue(cbxProductos.SelectedItem) as decimal? ?? 0m;

                if (btnAgregarProducto.Text == "Eliminar")
                {
                    facturaL.EliminarProducto(id);
                    MessageBox.Show("Producto eliminado de la factura", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var itemDTO = new ProductoFacturaDTO
                    {
                        Id = id,
                        Nombre = nombre,
                        Precio = precio,
                        Cantidad = cantidad
                    };
                    facturaL.AgregarProductoL(itemDTO);
                }

                ActualizarTablaFactura();
                ActualizarEstadoBoton();
                nudCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            btnCrearRegistro.Text = "Crear Producto";
            tbxNombre.PlaceholderText = "Ingrese el nombre del producto";
            tbxRegistro1.PlaceholderText = "Ingrese el precio del producto";
            tbxRegistro2.PlaceholderText = "Ingrese el stock del producto";

            
            if (btnRegistrarProducto.Text == "Registrar Nuevo Producto")
            {


                
                btnRegistrarProducto.Text = "Cancelar";
                btnRegistrarProducto.BackColor = Color.LightCoral;
                panelRegistro.Visible = true;
                tbxNombre.Focus(); 
            }
            else if (btnRegistrarProducto.Text == "Cancelar")
            {
                if (MessageBox.Show("¿Desea cancelar el registro?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnRegistrarProducto.Text = "Registrar Nuevo Producto";
                    btnRegistrarProducto.BackColor = Color.LightGreen;
                    panelRegistro.Visible = false;
                    LimpiarControles();
                }
            }

            


        }
    }
}
