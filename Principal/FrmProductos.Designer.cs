namespace Principal
{
    partial class frmProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            dgvDatos = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            btnEditar = new DataGridViewButtonColumn();
            btnEliminar = new DataGridViewButtonColumn();
            btnAgregar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            linkLabelProducto = new LinkLabel();
            btnFacturaVenta = new Button();
            pictureBox1 = new PictureBox();
            lbTitle = new Label();
            lbProv = new LinkLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            linkLabelFacturas = new LinkLabel();
            linkLabelUsuarios = new LinkLabel();
            linkLabelCategorias = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvDatos.BackgroundColor = SystemColors.ButtonFace;
            dgvDatos.BorderStyle = BorderStyle.Fixed3D;
            dgvDatos.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvDatos.ColumnHeadersHeight = 29;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { Id, btnEditar, btnEliminar });
            dgvDatos.Location = new Point(24, 166);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDatos.Size = new Size(1229, 440);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellContentClick += dgvDatos_CellContentClick;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Id.DataPropertyName = "Id";
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Resizable = DataGridViewTriState.True;
            Id.Width = 53;
            // 
            // btnEditar
            // 
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnEditar.HeaderText = "Editar";
            btnEditar.MinimumWidth = 6;
            btnEditar.Name = "btnEditar";
            btnEditar.ReadOnly = true;
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 54;
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.MinimumWidth = 6;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ReadOnly = true;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.Width = 69;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(1107, 127);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(146, 32);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AgregarProducto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Visible = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(200, 130);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 29);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Chartreuse;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(24, 130);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Visible = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // linkLabelProducto
            // 
            linkLabelProducto.AutoSize = true;
            linkLabelProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            linkLabelProducto.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelProducto.LinkColor = Color.Black;
            linkLabelProducto.Location = new Point(102, 5);
            linkLabelProducto.Name = "linkLabelProducto";
            linkLabelProducto.Size = new Size(107, 28);
            linkLabelProducto.TabIndex = 6;
            linkLabelProducto.TabStop = true;
            linkLabelProducto.Text = "Productos";
            linkLabelProducto.LinkClicked += linkLabelProducto_LinkClicked;
            // 
            // btnFacturaVenta
            // 
            btnFacturaVenta.AutoSize = true;
            btnFacturaVenta.FlatStyle = FlatStyle.Flat;
            btnFacturaVenta.Location = new Point(897, 127);
            btnFacturaVenta.Name = "btnFacturaVenta";
            btnFacturaVenta.Size = new Size(148, 32);
            btnFacturaVenta.TabIndex = 8;
            btnFacturaVenta.Text = "Crear Factura Venta";
            btnFacturaVenta.UseVisualStyleBackColor = true;
            btnFacturaVenta.Visible = false;
            btnFacturaVenta.Click += btnFacturaVenta_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = SystemColors.HotTrack;
            lbTitle.Location = new Point(148, 19);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(345, 50);
            lbTitle.TabIndex = 10;
            lbTitle.Text = "LaTiendaMásVeloz";
            // 
            // lbProv
            // 
            lbProv.AutoSize = true;
            lbProv.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbProv.LinkBehavior = LinkBehavior.NeverUnderline;
            lbProv.LinkColor = Color.Black;
            lbProv.Location = new Point(311, 5);
            lbProv.Name = "lbProv";
            lbProv.Size = new Size(129, 28);
            lbProv.TabIndex = 11;
            lbProv.TabStop = true;
            lbProv.Text = "Proveedores";
            lbProv.LinkClicked += lbProv_LinkClicked;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(linkLabelFacturas, 3, 0);
            tableLayoutPanel1.Controls.Add(lbProv, 4, 0);
            tableLayoutPanel1.Controls.Add(linkLabelProducto, 1, 0);
            tableLayoutPanel1.Controls.Add(linkLabelUsuarios, 0, 0);
            tableLayoutPanel1.Controls.Add(linkLabelCategorias, 5, 0);
            tableLayoutPanel1.Location = new Point(694, 26);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 5, 0, 5);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(559, 48);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // linkLabelFacturas
            // 
            linkLabelFacturas.AutoSize = true;
            linkLabelFacturas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            linkLabelFacturas.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelFacturas.LinkColor = Color.Black;
            linkLabelFacturas.Location = new Point(215, 5);
            linkLabelFacturas.Name = "linkLabelFacturas";
            linkLabelFacturas.Size = new Size(90, 28);
            linkLabelFacturas.TabIndex = 7;
            linkLabelFacturas.TabStop = true;
            linkLabelFacturas.Text = "Facturas";
            linkLabelFacturas.LinkClicked += linkLabelFacturas_LinkClicked;
            // 
            // linkLabelUsuarios
            // 
            linkLabelUsuarios.AutoSize = true;
            linkLabelUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            linkLabelUsuarios.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelUsuarios.LinkColor = Color.Black;
            linkLabelUsuarios.Location = new Point(3, 5);
            linkLabelUsuarios.Name = "linkLabelUsuarios";
            linkLabelUsuarios.Size = new Size(93, 28);
            linkLabelUsuarios.TabIndex = 5;
            linkLabelUsuarios.TabStop = true;
            linkLabelUsuarios.Text = "Usuarios";
            linkLabelUsuarios.Visible = false;
            linkLabelUsuarios.LinkClicked += linkLabelUsuarios_LinkClicked;
            // 
            // linkLabelCategorias
            // 
            linkLabelCategorias.AutoSize = true;
            linkLabelCategorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            linkLabelCategorias.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelCategorias.LinkColor = Color.Black;
            linkLabelCategorias.Location = new Point(446, 5);
            linkLabelCategorias.Name = "linkLabelCategorias";
            linkLabelCategorias.Size = new Size(112, 28);
            linkLabelCategorias.TabIndex = 12;
            linkLabelCategorias.TabStop = true;
            linkLabelCategorias.Text = "Categorias";
            linkLabelCategorias.LinkClicked += linkLabelCategorias_LinkClicked;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 618);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lbTitle);
            Controls.Add(pictureBox1);
            Controls.Add(btnFacturaVenta);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDatos);
            MaximizeBox = false;
            Name = "frmProductos";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProductos";
            Load += frmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private Button btnCancelar;
        private Button btnGuardar;
        private LinkLabel linkLabelProducto;
        private Button btnFacturaVenta;
        private PictureBox pictureBox1;
        private Label lbTitle;
        private LinkLabel lbProv;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewButtonColumn btnEditar;
        private DataGridViewButtonColumn btnEliminar;
        private LinkLabel linkLabelCategorias;
        private LinkLabel linkLabelFacturas;
        private LinkLabel linkLabelUsuarios;
    }
}