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
            dgvProductos = new DataGridView();
            btnAgregar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            linkLabelUsuarios = new LinkLabel();
            linkLabelProducto = new LinkLabel();
            linkLabelFacturas = new LinkLabel();
            Id = new DataGridViewTextBoxColumn();
            btnEditar = new DataGridViewButtonColumn();
            btnEliminar = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Id, btnEditar, btnEliminar });
            dgvProductos.Location = new Point(12, 98);
            dgvProductos.Margin = new Padding(3, 2, 3, 2);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.ScrollBars = ScrollBars.Horizontal;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProductos.Size = new Size(942, 232);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(832, 63);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(122, 22);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AgregarProducto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(677, 63);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 22);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Chartreuse;
            btnGuardar.Location = new Point(527, 63);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 22);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Visible = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // linkLabelUsuarios
            // 
            linkLabelUsuarios.AutoSize = true;
            linkLabelUsuarios.LinkColor = Color.Black;
            linkLabelUsuarios.Location = new Point(527, 18);
            linkLabelUsuarios.Name = "linkLabelUsuarios";
            linkLabelUsuarios.Size = new Size(52, 15);
            linkLabelUsuarios.TabIndex = 5;
            linkLabelUsuarios.TabStop = true;
            linkLabelUsuarios.Text = "Usuarios";
            linkLabelUsuarios.LinkClicked += linkLabelUsuarios_LinkClicked;
            // 
            // linkLabelProducto
            // 
            linkLabelProducto.AutoSize = true;
            linkLabelProducto.LinkColor = Color.Black;
            linkLabelProducto.Location = new Point(597, 18);
            linkLabelProducto.Name = "linkLabelProducto";
            linkLabelProducto.Size = new Size(61, 15);
            linkLabelProducto.TabIndex = 6;
            linkLabelProducto.TabStop = true;
            linkLabelProducto.Text = "Productos";
            linkLabelProducto.LinkClicked += linkLabelProducto_LinkClicked;
            // 
            // linkLabelFacturas
            // 
            linkLabelFacturas.AutoSize = true;
            linkLabelFacturas.LinkColor = Color.Black;
            linkLabelFacturas.Location = new Point(677, 18);
            linkLabelFacturas.Name = "linkLabelFacturas";
            linkLabelFacturas.Size = new Size(51, 15);
            linkLabelFacturas.TabIndex = 7;
            linkLabelFacturas.TabStop = true;
            linkLabelFacturas.Text = "Facturas";
            linkLabelFacturas.LinkClicked += linkLabelFacturas_LinkClicked;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            // 
            // btnEditar
            // 
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnEditar.HeaderText = "Editar";
            btnEditar.MinimumWidth = 6;
            btnEditar.Name = "btnEditar";
            btnEditar.ReadOnly = true;
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 134;
            // 
            // btnEliminar
            // 
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.MinimumWidth = 6;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ReadOnly = true;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 414);
            Controls.Add(linkLabelFacturas);
            Controls.Add(linkLabelProducto);
            Controls.Add(linkLabelUsuarios);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmProductos";
            Text = "frmProductos";
            Load += frmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private Button btnCancelar;
        private Button btnGuardar;
        private LinkLabel linkLabelUsuarios;
        private LinkLabel linkLabelProducto;
        private LinkLabel linkLabelFacturas;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewButtonColumn btnEditar;
        private DataGridViewButtonColumn btnEliminar;
    }
}