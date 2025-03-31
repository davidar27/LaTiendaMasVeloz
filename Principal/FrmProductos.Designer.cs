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
            components = new System.ComponentModel.Container();
            dgvProductos = new DataGridView();
            bindingSource1 = new BindingSource(components);
            btnAgregar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            Id = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            precioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            btnEditar = new DataGridViewButtonColumn();
            btnEliminar = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Id, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, precioDataGridViewTextBoxColumn, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, btnEditar, btnEliminar });
            dgvProductos.DataSource = bindingSource1;
            dgvProductos.Location = new Point(12, 80);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProductos.Size = new Size(1077, 310);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Modelo.Entities.Producto);
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(945, 26);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 29);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AgregarProducto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(768, 26);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 29);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Chartreuse;
            btnGuardar.Location = new Point(596, 26);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Visible = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Categoria";
            dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            precioDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Stock";
            dataGridViewTextBoxColumn4.HeaderText = "Stock";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Proveedor";
            dataGridViewTextBoxColumn5.HeaderText = "Proveedor";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 402);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductos);
            Name = "frmProductos";
            Text = "frmProductos";
            Load += frmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private BindingSource productoBindingSource;
        private BindingSource bindingSource1;
        private Button btnCancelar;
        private Button btnGuardar;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn btnEditar;
        private DataGridViewButtonColumn btnEliminar;
    }
}