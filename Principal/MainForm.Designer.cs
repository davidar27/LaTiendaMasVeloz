using Principal.Resources;


namespace Principal
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            labelTitulo = new Label();
            linkLabelAjust = new LinkLabel();
            linkLabelReport = new LinkLabel();
            linkLabelInventario = new LinkLabel();
            linkLabelDash = new LinkLabel();
            pictureHeader = new PictureBox();
            labelGestion = new Label();
            btnAgregarProduct = new BotonRedondeado();
            dgvProductos = new DataGridView();
            panelProducts = new PanelRedondeado();
            panel1 = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.None;
            panelHeader.BackColor = Color.FromArgb(242, 242, 242);
            panelHeader.Controls.Add(labelTitulo);
            panelHeader.Controls.Add(linkLabelAjust);
            panelHeader.Controls.Add(linkLabelReport);
            panelHeader.Controls.Add(linkLabelInventario);
            panelHeader.Controls.Add(linkLabelDash);
            panelHeader.Controls.Add(pictureHeader);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1199, 38);
            panelHeader.TabIndex = 1;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelTitulo.Location = new Point(54, 9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(201, 22);
            labelTitulo.TabIndex = 4;
            labelTitulo.Text = "La Tienda Más Veloz";
            // 
            // linkLabelAjust
            // 
            linkLabelAjust.AutoSize = true;
            linkLabelAjust.Location = new Point(1142, 13);
            linkLabelAjust.Name = "linkLabelAjust";
            linkLabelAjust.Size = new Size(45, 15);
            linkLabelAjust.TabIndex = 3;
            linkLabelAjust.TabStop = true;
            linkLabelAjust.Text = "Ajustes";
            // 
            // linkLabelReport
            // 
            linkLabelReport.AutoSize = true;
            linkLabelReport.Location = new Point(1083, 13);
            linkLabelReport.Name = "linkLabelReport";
            linkLabelReport.Size = new Size(53, 15);
            linkLabelReport.TabIndex = 3;
            linkLabelReport.TabStop = true;
            linkLabelReport.Text = "Reportes";
            // 
            // linkLabelInventario
            // 
            linkLabelInventario.AutoSize = true;
            linkLabelInventario.Location = new Point(1017, 13);
            linkLabelInventario.Name = "linkLabelInventario";
            linkLabelInventario.Size = new Size(60, 15);
            linkLabelInventario.TabIndex = 3;
            linkLabelInventario.TabStop = true;
            linkLabelInventario.Text = "Inventario";
            // 
            // linkLabelDash
            // 
            linkLabelDash.AutoSize = true;
            linkLabelDash.Location = new Point(947, 13);
            linkLabelDash.Name = "linkLabelDash";
            linkLabelDash.Size = new Size(64, 15);
            linkLabelDash.TabIndex = 3;
            linkLabelDash.TabStop = true;
            linkLabelDash.Text = "Dashboard";
            // 
            // pictureHeader
            // 
            pictureHeader.Image = (Image)resources.GetObject("pictureHeader.Image");
            pictureHeader.Location = new Point(12, 9);
            pictureHeader.Margin = new Padding(3, 2, 3, 2);
            pictureHeader.Name = "pictureHeader";
            pictureHeader.Size = new Size(26, 22);
            pictureHeader.SizeMode = PictureBoxSizeMode.Zoom;
            pictureHeader.TabIndex = 2;
            pictureHeader.TabStop = false;
            // 
            // labelGestion
            // 
            labelGestion.AutoSize = true;
            labelGestion.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelGestion.Location = new Point(4, 8);
            labelGestion.Name = "labelGestion";
            labelGestion.Size = new Size(208, 22);
            labelGestion.TabIndex = 2;
            labelGestion.Text = "Gestión de Inventario";
            // 
            // btnAgregarProduct
            // 
            btnAgregarProduct.BackColor = Color.FromArgb(76, 217, 99);
            btnAgregarProduct.FlatAppearance.BorderSize = 0;
            btnAgregarProduct.FlatStyle = FlatStyle.Flat;
            btnAgregarProduct.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnAgregarProduct.ImageAlign = ContentAlignment.BottomCenter;
            btnAgregarProduct.Location = new Point(1033, -1);
            btnAgregarProduct.Margin = new Padding(3, 2, 3, 2);
            btnAgregarProduct.Name = "btnAgregarProduct";
            btnAgregarProduct.Radio = 20;
            btnAgregarProduct.Size = new Size(144, 37);
            btnAgregarProduct.TabIndex = 3;
            btnAgregarProduct.Text = "+ Agregar Producto";
            btnAgregarProduct.TextAlign = ContentAlignment.BottomCenter;
            btnAgregarProduct.UseVisualStyleBackColor = false;
            btnAgregarProduct.Click += btnAgregarProducto_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Arial", 14F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Dock = DockStyle.Top;
            dgvProductos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(255, 255, 255);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Margin = new Padding(3, 2, 3, 2);
            dgvProductos.MaximumSize = new Size(1920, 1080);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 35;
            dgvProductos.Size = new Size(1199, 325);
            dgvProductos.TabIndex = 5;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick_1;
            // 
            // panelProducts
            // 
            panelProducts.AutoSize = true;
            panelProducts.Location = new Point(41, 169);
            panelProducts.Name = "panelProducts";
            panelProducts.Radio = 20;
            panelProducts.Size = new Size(484, 102);
            panelProducts.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 242, 242);
            panel1.Controls.Add(labelGestion);
            panel1.Controls.Add(btnAgregarProduct);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 403);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1199, 38);
            panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 441);
            Controls.Add(panel1);
            Controls.Add(panelProducts);
            Controls.Add(panelHeader);
            Controls.Add(dgvProductos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelHeader;
        private PictureBox pictureHeader;
        private LinkLabel linkLabelAjust;
        private LinkLabel linkLabelReport;
        private LinkLabel linkLabelInventario;
        private LinkLabel linkLabelDash;
        private Label labelTitulo;
        private Label labelGestion;
        private BotonRedondeado btnAgregarProduct;
        private DataGridView dgvProductos;
        private PanelRedondeado panelProducts;
        private Panel panel1;
    }
}
