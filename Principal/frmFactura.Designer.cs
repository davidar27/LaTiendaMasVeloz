namespace Principal
{
    partial class frmFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvFacturaProductos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            productoFacturaDTOBindingSource = new BindingSource(components);
            productoFacturaBindingSource = new BindingSource(components);
            cbxProductos = new ComboBox();
            btnAgregarProducto = new Button();
            nudCantidad = new NumericUpDown();
            label1 = new Label();
            lbNTipo = new Label();
            cbxEntidad = new ComboBox();
            clienteDTOBindingSource = new BindingSource(components);
            btnGuardarFactura = new Button();
            PanelProduct = new Panel();
            btnMostReg = new Button();
            txtFecha = new Label();
            panelRegistro = new Panel();
            tbxRegistro1 = new TextBox();
            tbxRegistro2 = new TextBox();
            tbxNombre = new TextBox();
            btnCrearRegistro = new Button();
            cbxEmpleado = new ComboBox();
            lbEmpleado = new Label();
            btnRegistrarProducto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturaProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoFacturaDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoFacturaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteDTOBindingSource).BeginInit();
            PanelProduct.SuspendLayout();
            panelRegistro.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFacturaProductos
            // 
            dgvFacturaProductos.AllowUserToDeleteRows = false;
            dgvFacturaProductos.AllowUserToResizeColumns = false;
            dgvFacturaProductos.AllowUserToResizeRows = false;
            dgvFacturaProductos.AutoGenerateColumns = false;
            dgvFacturaProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturaProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFacturaProductos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvFacturaProductos.BorderStyle = BorderStyle.Fixed3D;
            dgvFacturaProductos.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvFacturaProductos.ColumnHeadersHeight = 29;
            dgvFacturaProductos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvFacturaProductos.DataSource = productoFacturaDTOBindingSource;
            dgvFacturaProductos.Location = new Point(81, 383);
            dgvFacturaProductos.Name = "dgvFacturaProductos";
            dgvFacturaProductos.ReadOnly = true;
            dgvFacturaProductos.RowHeadersVisible = false;
            dgvFacturaProductos.RowHeadersWidth = 51;
            dgvFacturaProductos.ScrollBars = ScrollBars.Horizontal;
            dgvFacturaProductos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvFacturaProductos.Size = new Size(1176, 188);
            dgvFacturaProductos.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Precio";
            dataGridViewTextBoxColumn3.HeaderText = "Precio";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Cantidad";
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Subtotal";
            dataGridViewTextBoxColumn5.HeaderText = "Subtotal";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // productoFacturaDTOBindingSource
            // 
            productoFacturaDTOBindingSource.DataSource = typeof(Logica.DTO.ProductoFacturaDTO);
            // 
            // cbxProductos
            // 
            cbxProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProductos.FormattingEnabled = true;
            cbxProductos.Location = new Point(49, 30);
            cbxProductos.Margin = new Padding(3, 4, 3, 4);
            cbxProductos.Name = "cbxProductos";
            cbxProductos.Size = new Size(262, 28);
            cbxProductos.TabIndex = 4;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(128, 255, 128);
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Location = new Point(99, 146);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(153, 40);
            btnAgregarProducto.TabIndex = 5;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(49, 93);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(262, 27);
            nudCantidad.TabIndex = 7;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 93);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 10;
            label1.Text = "Fecha de emisión";
            // 
            // lbNTipo
            // 
            lbNTipo.AutoSize = true;
            lbNTipo.Location = new Point(81, 188);
            lbNTipo.Name = "lbNTipo";
            lbNTipo.Size = new Size(55, 20);
            lbNTipo.TabIndex = 12;
            lbNTipo.Text = "Cliente";
            // 
            // cbxEntidad
            // 
            cbxEntidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbxEntidad.DataSource = clienteDTOBindingSource;
            cbxEntidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEntidad.DropDownWidth = 250;
            cbxEntidad.FormattingEnabled = true;
            cbxEntidad.Location = new Point(239, 185);
            cbxEntidad.Margin = new Padding(3, 4, 3, 4);
            cbxEntidad.Name = "cbxEntidad";
            cbxEntidad.Size = new Size(224, 28);
            cbxEntidad.TabIndex = 13;
            // 
            // clienteDTOBindingSource
            // 
            clienteDTOBindingSource.DataSource = typeof(Logica.DTO.ClienteDTO);
            // 
            // btnGuardarFactura
            // 
            btnGuardarFactura.BackColor = Color.PaleGreen;
            btnGuardarFactura.FlatStyle = FlatStyle.Flat;
            btnGuardarFactura.Location = new Point(1072, 335);
            btnGuardarFactura.Name = "btnGuardarFactura";
            btnGuardarFactura.Size = new Size(185, 42);
            btnGuardarFactura.TabIndex = 14;
            btnGuardarFactura.Text = "Guardar Factura";
            btnGuardarFactura.UseVisualStyleBackColor = false;
            btnGuardarFactura.Click += btnGuardarFactura_Click;
            // 
            // PanelProduct
            // 
            PanelProduct.Controls.Add(cbxProductos);
            PanelProduct.Controls.Add(nudCantidad);
            PanelProduct.Controls.Add(btnAgregarProducto);
            PanelProduct.Location = new Point(906, 58);
            PanelProduct.Name = "PanelProduct";
            PanelProduct.Size = new Size(351, 218);
            PanelProduct.TabIndex = 15;
            // 
            // btnMostReg
            // 
            btnMostReg.AutoSize = true;
            btnMostReg.BackColor = Color.LightGreen;
            btnMostReg.FlatStyle = FlatStyle.Flat;
            btnMostReg.Location = new Point(81, 335);
            btnMostReg.Name = "btnMostReg";
            btnMostReg.Size = new Size(177, 40);
            btnMostReg.TabIndex = 16;
            btnMostReg.Text = "Registrar Nuevo Cliente";
            btnMostReg.UseVisualStyleBackColor = false;
            btnMostReg.Click += btnMostReg_Click;
            // 
            // txtFecha
            // 
            txtFecha.AutoSize = true;
            txtFecha.Location = new Point(239, 93);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(47, 20);
            txtFecha.TabIndex = 18;
            txtFecha.Text = "Fecha";
            // 
            // panelRegistro
            // 
            panelRegistro.Controls.Add(tbxRegistro1);
            panelRegistro.Controls.Add(tbxRegistro2);
            panelRegistro.Controls.Add(tbxNombre);
            panelRegistro.Controls.Add(btnCrearRegistro);
            panelRegistro.Location = new Point(513, 58);
            panelRegistro.Name = "panelRegistro";
            panelRegistro.Size = new Size(375, 218);
            panelRegistro.TabIndex = 16;
            panelRegistro.Visible = false;
            // 
            // tbxRegistro1
            // 
            tbxRegistro1.Location = new Point(35, 80);
            tbxRegistro1.Name = "tbxRegistro1";
            tbxRegistro1.PlaceholderText = "Apellido";
            tbxRegistro1.Size = new Size(313, 27);
            tbxRegistro1.TabIndex = 21;
            // 
            // tbxRegistro2
            // 
            tbxRegistro2.Location = new Point(35, 127);
            tbxRegistro2.Name = "tbxRegistro2";
            tbxRegistro2.PlaceholderText = "Correo";
            tbxRegistro2.Size = new Size(313, 27);
            tbxRegistro2.TabIndex = 20;
            // 
            // tbxNombre
            // 
            tbxNombre.Location = new Point(35, 35);
            tbxNombre.Name = "tbxNombre";
            tbxNombre.PlaceholderText = "Nombre";
            tbxNombre.Size = new Size(313, 27);
            tbxNombre.TabIndex = 19;
            // 
            // btnCrearRegistro
            // 
            btnCrearRegistro.FlatStyle = FlatStyle.Flat;
            btnCrearRegistro.Location = new Point(113, 163);
            btnCrearRegistro.Name = "btnCrearRegistro";
            btnCrearRegistro.Size = new Size(153, 40);
            btnCrearRegistro.TabIndex = 5;
            btnCrearRegistro.Text = "Crear Cliente";
            btnCrearRegistro.UseVisualStyleBackColor = true;
            btnCrearRegistro.Click += btnCrearCliente_Click;
            // 
            // cbxEmpleado
            // 
            cbxEmpleado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbxEmpleado.DataSource = clienteDTOBindingSource;
            cbxEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEmpleado.DropDownWidth = 250;
            cbxEmpleado.FormattingEnabled = true;
            cbxEmpleado.Location = new Point(239, 138);
            cbxEmpleado.Margin = new Padding(3, 4, 3, 4);
            cbxEmpleado.Name = "cbxEmpleado";
            cbxEmpleado.Size = new Size(224, 28);
            cbxEmpleado.TabIndex = 21;
            // 
            // lbEmpleado
            // 
            lbEmpleado.AutoSize = true;
            lbEmpleado.Location = new Point(81, 141);
            lbEmpleado.Name = "lbEmpleado";
            lbEmpleado.Size = new Size(77, 20);
            lbEmpleado.TabIndex = 20;
            lbEmpleado.Text = "Empleado";
            // 
            // btnRegistrarProducto
            // 
            btnRegistrarProducto.AutoSize = true;
            btnRegistrarProducto.BackColor = Color.LightGreen;
            btnRegistrarProducto.FlatStyle = FlatStyle.Flat;
            btnRegistrarProducto.Location = new Point(321, 335);
            btnRegistrarProducto.Name = "btnRegistrarProducto";
            btnRegistrarProducto.Size = new Size(191, 40);
            btnRegistrarProducto.TabIndex = 22;
            btnRegistrarProducto.Text = "Registrar Nuevo Producto";
            btnRegistrarProducto.UseVisualStyleBackColor = false;
            btnRegistrarProducto.Click += btnRegistrarProducto_Click;
            // 
            // frmFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1353, 905);
            Controls.Add(btnRegistrarProducto);
            Controls.Add(cbxEmpleado);
            Controls.Add(lbEmpleado);
            Controls.Add(panelRegistro);
            Controls.Add(txtFecha);
            Controls.Add(btnMostReg);
            Controls.Add(PanelProduct);
            Controls.Add(btnGuardarFactura);
            Controls.Add(cbxEntidad);
            Controls.Add(lbNTipo);
            Controls.Add(label1);
            Controls.Add(dgvFacturaProductos);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimumSize = new Size(1369, 942);
            Name = "frmFactura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura";
            Load += frmFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturaProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoFacturaDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoFacturaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteDTOBindingSource).EndInit();
            PanelProduct.ResumeLayout(false);
            panelRegistro.ResumeLayout(false);
            panelRegistro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvDatos;
        private DataGridViewButtonColumn btnAgregar;
        private DataGridView dgvFacturaProductos;
        private ComboBox cbxProductos;
        private Button btnAgregarProducto;
        private NumericUpDown nudCantidad;
        private TextBox tbxRegistro2;
        private Label label1;
        private Label lbNFactura;
        private Label lbNTipo;
        private ComboBox cbxEntidad;
        private Button btnGuardarFactura;
        private Panel PanelProduct;
        private Button btnMostReg;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private BindingSource productoFacturaBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private BindingSource productoFacturaDTOBindingSource;
        private Label txtFecha;
        private Panel panelRegistro;
        private TextBox tbxNombre;
        private Button btnCrearRegistro;
        private TextBox tbxRegistro1;
        private BindingSource clienteDTOBindingSource;
        private ComboBox cbxEmpleado;
        private Label lbEmpleado;
        private Button btnRegistrarProducto;
        private TextBox tbxFactura;
    }
}