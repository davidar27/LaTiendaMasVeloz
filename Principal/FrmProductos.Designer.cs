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
            dgvDatos = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            btnEditar = new DataGridViewButtonColumn();
            btnEliminar = new DataGridViewButtonColumn();
            btnAgregar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            linkLabelUsuarios = new LinkLabel();
            linkLabelProducto = new LinkLabel();
            linkLabelFacturas = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDatos.ColumnHeadersHeight = 29;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { Id, btnEditar, btnEliminar });
            dgvDatos.Location = new Point(14, 131);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.ScrollBars = ScrollBars.Horizontal;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDatos.Size = new Size(1077, 309);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellContentClick += dgvDatos_CellContentClick;
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
            // btnAgregar
            // 
            btnAgregar.Location = new Point(951, 84);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(139, 29);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AgregarProducto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(774, 84);
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
            btnGuardar.Location = new Point(602, 84);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 29);
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
            linkLabelUsuarios.Location = new Point(602, 24);
            linkLabelUsuarios.Name = "linkLabelUsuarios";
            linkLabelUsuarios.Size = new Size(65, 20);
            linkLabelUsuarios.TabIndex = 5;
            linkLabelUsuarios.TabStop = true;
            linkLabelUsuarios.Text = "Usuarios";
            linkLabelUsuarios.LinkClicked += linkLabelUsuarios_LinkClicked;
            // 
            // linkLabelProducto
            // 
            linkLabelProducto.AutoSize = true;
            linkLabelProducto.LinkColor = Color.Black;
            linkLabelProducto.Location = new Point(682, 24);
            linkLabelProducto.Name = "linkLabelProducto";
            linkLabelProducto.Size = new Size(75, 20);
            linkLabelProducto.TabIndex = 6;
            linkLabelProducto.TabStop = true;
            linkLabelProducto.Text = "Productos";
            linkLabelProducto.LinkClicked += linkLabelProducto_LinkClicked;
            // 
            // linkLabelFacturas
            // 
            linkLabelFacturas.AutoSize = true;
            linkLabelFacturas.LinkColor = Color.Black;
            linkLabelFacturas.Location = new Point(774, 24);
            linkLabelFacturas.Name = "linkLabelFacturas";
            linkLabelFacturas.Size = new Size(62, 20);
            linkLabelFacturas.TabIndex = 7;
            linkLabelFacturas.TabStop = true;
            linkLabelFacturas.Text = "Facturas";
            linkLabelFacturas.LinkClicked += linkLabelFacturas_LinkClicked;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 552);
            Controls.Add(linkLabelFacturas);
            Controls.Add(linkLabelProducto);
            Controls.Add(linkLabelUsuarios);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDatos);
            Name = "frmProductos";
            Text = "frmProductos";
            Load += frmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
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
        private LinkLabel linkLabelUsuarios;
        private LinkLabel linkLabelProducto;
        private LinkLabel linkLabelFacturas;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewButtonColumn btnEditar;
        private DataGridViewButtonColumn btnEliminar;
    }
}