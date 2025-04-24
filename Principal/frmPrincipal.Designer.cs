namespace Principal
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            btnEmpleado = new Button();
            btnAdmin = new Button();
            SuspendLayout();
            // 
            // btnEmpleado
            // 
            btnEmpleado.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmpleado.Image = (Image)resources.GetObject("btnEmpleado.Image");
            btnEmpleado.ImageAlign = ContentAlignment.TopCenter;
            btnEmpleado.Location = new Point(419, 47);
            btnEmpleado.Margin = new Padding(3, 4, 3, 4);
            btnEmpleado.Name = "btnEmpleado";
            btnEmpleado.Size = new Size(277, 309);
            btnEmpleado.TabIndex = 1;
            btnEmpleado.Text = "Empleado";
            btnEmpleado.TextAlign = ContentAlignment.TopCenter;
            btnEmpleado.UseVisualStyleBackColor = true;
            btnEmpleado.Click += btnEmpleado_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.AutoSize = true;
            btnAdmin.BackgroundImageLayout = ImageLayout.None;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdmin.Image = (Image)resources.GetObject("btnAdmin.Image");
            btnAdmin.ImageAlign = ContentAlignment.TopCenter;
            btnAdmin.Location = new Point(97, 47);
            btnAdmin.Margin = new Padding(3, 4, 3, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(277, 309);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "Admin";
            btnAdmin.TextAlign = ContentAlignment.BottomCenter;
            btnAdmin.TextImageRelation = TextImageRelation.TextAboveImage;
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 410);
            Controls.Add(btnAdmin);
            Controls.Add(btnEmpleado);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmpleado;
        private Button btnAdmin;
    }
}