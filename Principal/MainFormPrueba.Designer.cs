namespace Principal
{
    partial class MainFormPrueba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormPrueba));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayout = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            linkLabelAjust = new LinkLabel();
            linkLabelReport = new LinkLabel();
            linkLabelDash = new LinkLabel();
            linkLabelInventario = new LinkLabel();
            pictureHeader = new PictureBox();
            labelTitulo = new Label();
            dgvProducts = new DataGridView();
            panel2 = new Panel();
            labelGestion = new Label();
            btnAgregarProduct = new Principal.Resources.BotonRedondeado();
            tableLayout.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayout.Controls.Add(panel1, 0, 0);
            tableLayout.Controls.Add(dgvProducts, 0, 2);
            tableLayout.Controls.Add(panel2, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(0, 0);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.Size = new Size(800, 561);
            tableLayout.TabIndex = 0;
            tableLayout.Paint += tableLayout_Paint;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pictureHeader);
            panel1.Controls.Add(labelTitulo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8);
            panel1.Size = new Size(794, 44);
            panel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(linkLabelAjust);
            panel3.Controls.Add(linkLabelReport);
            panel3.Controls.Add(linkLabelDash);
            panel3.Controls.Add(linkLabelInventario);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(484, 8);
            panel3.Name = "panel3";
            panel3.Size = new Size(302, 28);
            panel3.TabIndex = 11;
            // 
            // linkLabelAjust
            // 
            linkLabelAjust.AutoSize = true;
            linkLabelAjust.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelAjust.LinkColor = Color.Black;
            linkLabelAjust.Location = new Point(230, 8);
            linkLabelAjust.Name = "linkLabelAjust";
            linkLabelAjust.Size = new Size(45, 15);
            linkLabelAjust.TabIndex = 7;
            linkLabelAjust.TabStop = true;
            linkLabelAjust.Text = "Ajustes";
            linkLabelAjust.LinkClicked += linkLabelAjust_LinkClicked;
            // 
            // linkLabelReport
            // 
            linkLabelReport.AutoSize = true;
            linkLabelReport.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelReport.LinkColor = Color.Black;
            linkLabelReport.Location = new Point(171, 8);
            linkLabelReport.Name = "linkLabelReport";
            linkLabelReport.Size = new Size(53, 15);
            linkLabelReport.TabIndex = 8;
            linkLabelReport.TabStop = true;
            linkLabelReport.Text = "Reportes";
            // 
            // linkLabelDash
            // 
            linkLabelDash.AutoSize = true;
            linkLabelDash.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelDash.LinkColor = Color.Black;
            linkLabelDash.Location = new Point(35, 8);
            linkLabelDash.Name = "linkLabelDash";
            linkLabelDash.Size = new Size(64, 15);
            linkLabelDash.TabIndex = 10;
            linkLabelDash.TabStop = true;
            linkLabelDash.Text = "Dashboard";
            linkLabelDash.UseMnemonic = false;
            // 
            // linkLabelInventario
            // 
            linkLabelInventario.AutoSize = true;
            linkLabelInventario.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelInventario.LinkColor = Color.Black;
            linkLabelInventario.Location = new Point(105, 8);
            linkLabelInventario.Name = "linkLabelInventario";
            linkLabelInventario.Size = new Size(60, 15);
            linkLabelInventario.TabIndex = 9;
            linkLabelInventario.TabStop = true;
            linkLabelInventario.Text = "Inventario";
            // 
            // pictureHeader
            // 
            pictureHeader.Image = (Image)resources.GetObject("pictureHeader.Image");
            pictureHeader.Location = new Point(18, 11);
            pictureHeader.Margin = new Padding(3, 2, 3, 2);
            pictureHeader.Name = "pictureHeader";
            pictureHeader.Size = new Size(26, 22);
            pictureHeader.SizeMode = PictureBoxSizeMode.Zoom;
            pictureHeader.TabIndex = 5;
            pictureHeader.TabStop = false;
            pictureHeader.Click += pictureHeader_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelTitulo.Location = new Point(77, 10);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(201, 22);
            labelTitulo.TabIndex = 6;
            labelTitulo.Text = "La Tienda Más Veloz";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToResizeColumns = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 103);
            dgvProducts.MaximumSize = new Size(1920, 1080);
            dgvProducts.MinimumSize = new Size(800, 600);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ShowCellErrors = false;
            dgvProducts.ShowCellToolTips = false;
            dgvProducts.ShowEditingIcon = false;
            dgvProducts.ShowRowErrors = false;
            dgvProducts.Size = new Size(800, 600);
            dgvProducts.TabIndex = 11;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(labelGestion);
            panel2.Controls.Add(btnAgregarProduct);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 53);
            panel2.MaximumSize = new Size(1920, 0);
            panel2.MinimumSize = new Size(600, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(794, 44);
            panel2.TabIndex = 10;
            // 
            // labelGestion
            // 
            labelGestion.AutoSize = true;
            labelGestion.Dock = DockStyle.Left;
            labelGestion.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelGestion.Location = new Point(8, 8);
            labelGestion.Name = "labelGestion";
            labelGestion.Size = new Size(208, 22);
            labelGestion.TabIndex = 8;
            labelGestion.Text = "Gestión de Inventario";
            labelGestion.Click += labelGestion_Click;
            // 
            // btnAgregarProduct
            // 
            btnAgregarProduct.BackColor = Color.FromArgb(76, 217, 99);
            btnAgregarProduct.Dock = DockStyle.Right;
            btnAgregarProduct.FlatAppearance.BorderSize = 0;
            btnAgregarProduct.FlatStyle = FlatStyle.Flat;
            btnAgregarProduct.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnAgregarProduct.ImageAlign = ContentAlignment.BottomCenter;
            btnAgregarProduct.Location = new Point(615, 8);
            btnAgregarProduct.Margin = new Padding(3, 2, 3, 2);
            btnAgregarProduct.Name = "btnAgregarProduct";
            btnAgregarProduct.Radio = 20;
            btnAgregarProduct.Size = new Size(171, 28);
            btnAgregarProduct.TabIndex = 9;
            btnAgregarProduct.Text = "+ Agregar Producto";
            btnAgregarProduct.TextAlign = ContentAlignment.BottomCenter;
            btnAgregarProduct.UseVisualStyleBackColor = false;
            btnAgregarProduct.Click += btnAgregarProduct_Click;
            // 
            // MainFormPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 561);
            Controls.Add(tableLayout);
            MinimumSize = new Size(800, 600);
            Name = "MainFormPrueba";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainFormPrueba";
            Load += MainFormPrueba_Load;
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);



        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayout;
        private Label labelTitulo;
        private PictureBox pictureHeader;
        private Panel panel1;
        private LinkLabel linkLabelAjust;
        private LinkLabel linkLabelReport;
        private LinkLabel linkLabelInventario;
        private LinkLabel linkLabelDash;
        private Label labelGestion;
        private Resources.BotonRedondeado btnAgregarProduct;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewButtonColumn Column1;
        protected DataGridView dgvProducts;
    }
}