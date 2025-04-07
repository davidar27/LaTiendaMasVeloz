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
            dgvDatos = new DataGridView();
            btnAgregar = new DataGridViewButtonColumn();
            dgvFactura = new DataGridView();
            productoBindingSource = new BindingSource(components);
            comboBoxProductos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFactura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
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
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { btnAgregar });
            dgvDatos.Location = new Point(24, 64);
            dgvDatos.Margin = new Padding(3, 2, 3, 2);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.ScrollBars = ScrollBars.Horizontal;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDatos.Size = new Size(516, 302);
            dgvDatos.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnAgregar.HeaderText = "Agregar";
            btnAgregar.MinimumWidth = 6;
            btnAgregar.Name = "btnAgregar";
            btnAgregar.ReadOnly = true;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseColumnTextForButtonValue = true;
            btnAgregar.Width = 134;
            // 
            // dgvFactura
            // 
            dgvFactura.AllowUserToAddRows = false;
            dgvFactura.AllowUserToDeleteRows = false;
            dgvFactura.AllowUserToResizeColumns = false;
            dgvFactura.AllowUserToResizeRows = false;
            dgvFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFactura.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFactura.ColumnHeadersHeight = 29;
            dgvFactura.Location = new Point(583, 64);
            dgvFactura.Margin = new Padding(3, 2, 3, 2);
            dgvFactura.Name = "dgvFactura";
            dgvFactura.RowHeadersVisible = false;
            dgvFactura.RowHeadersWidth = 51;
            dgvFactura.ScrollBars = ScrollBars.Horizontal;
            dgvFactura.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvFactura.Size = new Size(516, 563);
            dgvFactura.TabIndex = 3;
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Modelo.Entities.Producto);
            // 
            // comboBoxProductos
            // 
            comboBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductos.FormattingEnabled = true;
            comboBoxProductos.Location = new Point(147, 12);
            comboBoxProductos.Name = "comboBoxProductos";
            comboBoxProductos.Size = new Size(230, 23);
            comboBoxProductos.TabIndex = 4;
            // 
            // frmFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1184, 679);
            Controls.Add(comboBoxProductos);
            Controls.Add(dgvFactura);
            Controls.Add(dgvDatos);
            MinimumSize = new Size(1200, 718);
            Name = "frmFactura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFactura).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvDatos;
        private DataGridViewButtonColumn btnAgregar;
        private DataGridView dgvFactura;
        private BindingSource productoBindingSource;
        private ComboBox comboBoxProductos;
    }
}